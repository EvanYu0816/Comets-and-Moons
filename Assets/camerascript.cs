using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour {
    Camera cam;
    public GameObject c, cc, st, ball, orb;
    List<GameObject> al;
    float y, r, h, w;
    public float gap, v;
    public static float maxh;
    int maxit; 
    Vector3 cpos;
    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
        float sw = Screen.width, sh = Screen.height;
        if (16 * sw >= 10 * sh) cam.rect = new Rect(0, 0, 1, 1);
        else
        {
            float dif = sh - 16 * sw / 10;
            cam.rect = new Rect(0, dif / 2 / sh, 1, 1 - dif / sh);
        }
    }
    void Start () {
        maxh = -3;
        al = new List<GameObject>();
        r = c.GetComponent<SpriteRenderer>().bounds.extents.x;
        h = Camera.main.orthographicSize;
        w = Camera.main.aspect * h;
        y = st.transform.position.y;
        //Debug.Log(st == null);
        al.Add(st);
        while (y < h) spawn();    
    }
    void spawn() {
        //Debug.Log(r1); 
        float x = Random.Range(0.8f - w, w - 0.8f);
        GameObject lst = al[al.Count - 1];
        Vector3 pos = lst.transform.position;
        float r2 = getr(lst.transform.localScale.x);
        float dmin = gap + r2 + 0.6f;
        float dx = pos.x - x;
        float ymin = Mathf.Sqrt(Mathf.Max(dmin * dmin - dx * dx, 0));
        y +=  Random.Range(Mathf.Max(ymin, 0.5f), 3f);
        float dist = BallScript.eucdist(pos.x, x, pos.y, y);
        float rmax1 = dist - r2 - gap;
        float rmax2 = Mathf.Min(Mathf.Abs(x - (w-0.2f)), Mathf.Abs(x - (0.2f-w)));
        //Debug.Log(rmax1 + " " + rmax2+ " " + dist + " " + dmin + " " +  ymin); 
        float smax = Mathf.Min(rmax1, rmax2) / 2.4f;
        float scale = Random.Range(0.25f, smax);
        float r1 = getr(scale);
        //Debug.Log(ming + " " + r1 + " " + r + " " + scale); 
        foreach (GameObject i in al){
            Vector3 posi = i.transform.position;
            float r3 = getr(i.transform.localScale.x);
            float di = gap + r3 + r1;
            float dxi = posi.x - x;
            float dyi = Mathf.Sqrt(Mathf.Max(di * di - dxi * dxi, 0));
            y = Mathf.Max(posi.y + dyi, y); 
        } GameObject ob;
        if (lst.tag == "c") ob = Instantiate(cc);
        else ob = Instantiate(c);
        ob.transform.position = new Vector3(x, y, 0);
        ob.transform.localScale = new Vector3(scale, scale, 0);
        al.Add(ob);
        if (Random.Range(0,5)>=4 && al.Count >= 5){
            GameObject eorb = Instantiate(orb, ob.transform);
            //eorb.transform.Translate(ob.transform.position);
            eorb.transform.Translate(new Vector3(r1+0.4f, 0, 0));
            eorb.transform.localScale = (new Vector3(0.05f / scale, 0.05f / scale, 0));
            if (lst.tag == "c") eorb.GetComponent<OrbObstacle>().initlz(ob.transform.position, Vector3.back);
            else eorb.GetComponent<OrbObstacle>().initlz(ob.transform.position, Vector3.forward);
        }

    }
    float getr(float scale) { return scale / c.transform.localScale.x * r; }
    float top (GameObject go){
        return go.transform.position.y + getr(go.transform.localScale.x);
    }
    void Update () {
        cpos = transform.position;
        //Debug.Log(maxh + " " + cpos.y); 
        if (cpos.y < maxh && !BallScript.ded) transform.Translate(new Vector3(0, v * Time.deltaTime, 0));
        if (top(al[0]) < cpos.y-h){
            GameObject go = al[0]; 
            al.RemoveAt(0); DestroyImmediate(go);
        } if (y - 1 <= cpos.y+h) spawn();

        
    } 

}
