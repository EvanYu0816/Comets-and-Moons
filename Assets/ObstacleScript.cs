using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

    public bool c; 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown(){
        if (c) BallScript.upd(transform.position, Vector3.back);
        else BallScript.upd(transform.position, Vector3.forward);
    }
}
