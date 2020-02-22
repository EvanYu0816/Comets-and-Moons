using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foricon : MonoBehaviour {

	// Use this for initialization
	void Start () {



    }

    // Update is called once per frame
    void Update () {
        transform.RotateAround(new Vector3(0, -5, 0), Vector3.back, 180*Time.deltaTime);
	}
}
