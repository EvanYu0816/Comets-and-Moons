using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startball : MonoBehaviour {

    Vector3 axis, dir;
    public float v;
    void Awake()
    {
        if (PlayerPrefs.HasKey("sx")){
            transform.position = new Vector3(PlayerPrefs.GetFloat("sx"), PlayerPrefs.GetFloat("sy"), -0.5f);
        }     
    }
    void Start () {
        axis = new Vector3(0, -3, 0);
        dir = Vector3.back; 
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(axis, dir, Mathf.Rad2Deg * v * Time.deltaTime);
    }
}
