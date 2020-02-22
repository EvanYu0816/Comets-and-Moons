using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene2cam : MonoBehaviour
{
    Camera cam;
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
   

}