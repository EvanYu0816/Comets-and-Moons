using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterbox : MonoBehaviour {

    public GameObject cam;
    public bool top; 
	void Start () {
        Camera c = cam.GetComponent<Camera>();
        float h = c.rect.y;
        //Debug.Log(h); 
        if (top)
            gameObject.GetComponent<Camera>().rect = new Rect(0, 1-h, 1, h);
        else {
            gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 1, h);
        }
	}
}
