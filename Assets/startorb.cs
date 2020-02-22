using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startorb : MonoBehaviour {

    public Vector3 axis, pos;
    float r; public float v;

    void Start()
    {
        pos = transform.position;
        r = BallScript.eucdist(pos.x, axis.x, pos.y, axis.y);
    }
    void Update()
    {

        transform.RotateAround(axis, Vector3.back, Mathf.Rad2Deg * v / r * Time.deltaTime);
        //Debug.Log(axis.x + " " + axis.y + " " + axis.z);
    }
}
