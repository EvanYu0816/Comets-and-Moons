using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbObstacle : MonoBehaviour {

    // Use this for initialization

    Vector3 axis, dir, pos;
    float r; public float v, a; 
    void Update () {
        transform.RotateAround(axis, dir, Mathf.Rad2Deg * v / r * Time.deltaTime);
        //Debug.Log(axis.x + " " + axis.y + " " + axis.z);
    }
    public void initlz (Vector3 a, Vector3 d){
        axis = a; dir = d;
        pos = transform.position;
        r = BallScript.eucdist(pos.x, a.x, pos.y, a.y);
    }
    
}
