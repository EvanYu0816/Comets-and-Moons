using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallScript : MonoBehaviour
{

    public static Vector3 axis, dir, pos;
    
    public static float r, av;
    public static bool ded; 
    public float v;
    float h, w;
    public GameObject ps, cam;
    bool inbd, ivk, go;
    void Awake()
    {
        pos = transform.position = new Vector3(PlayerPrefs.GetFloat("sx"), PlayerPrefs.GetFloat("sy"), -0.5f);
    }
    void Start()
    {
        ded = false;
        upd(new Vector3(0, -3, 0), Vector3.back);
        h = Camera.main.orthographicSize;
        w = Camera.main.aspect * h;
        ivk = false;
        //InvokeRepeating("acc", 5, 5);
    }
    void Update()
    {
        if (go) return; 
        Vector3 cpos = cam.transform.position;
        pos = transform.position;
        transform.RotateAround(axis, dir, Mathf.Rad2Deg * v / r * Time.deltaTime);
        inbd = pos.y >= cpos.y - h-0.25f && pos.y <= cpos.y + h+ 0.25f && pos.x >= cpos.x - w- 0.25f && pos.x <= cpos.x + w+ 0.25f;
        //Debug.Log(inbd);
        if (!inbd && !ivk) { ivk = true; Invoke("db2", 2); }
        if (inbd && ivk) { ivk = false; CancelInvoke(); }

    }
    public static void upd(Vector3 a, Vector3 d)
    {
        axis = a; dir = d;
        r = eucdist(pos.x, a.x, pos.y, a.y);
        camerascript.maxh = Mathf.Max(camerascript.maxh, a.y);
    }
    public static float eucdist(float x1, float x2, float y1, float y2)
    {
        return Mathf.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("hit");
        string tg = col.gameObject.tag;
        if (tg == "cc" || tg == "c") gg();

    }
    void gg()
    {
        go = true;
        Instantiate(ps, transform.position, Quaternion.identity);
        Invoke("db", 2);
        ded = true;
        PlayerPrefs.SetString("gg", "Disintegrated");
        PlayerPrefs.SetInt("sc", (int)transform.position.y+2);
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        Destroy(gameObject.GetComponent<TrailRenderer>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    } void db() {
        Debug.Log("db");
        PlayerPrefs.SetFloat("sx", 0);
        PlayerPrefs.SetFloat("sy", -2);

        if (!PlayerPrefs.HasKey("hsc")) PlayerPrefs.SetInt("hsc", PlayerPrefs.GetInt("sc"));
        else PlayerPrefs.SetInt("hsc", Mathf.Max(PlayerPrefs.GetInt("sc"), PlayerPrefs.GetInt("hsc")));
        SceneManager.LoadScene("GGScene", LoadSceneMode.Single);
        Destroy(gameObject);
    }
    void db2 (){
        ivk = false;
        if (!inbd) { 
            PlayerPrefs.SetString("gg", "Wandered Away");
            PlayerPrefs.SetInt("sc", (int)transform.position.y + 2);
            db();
        }
    }
}
