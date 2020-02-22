using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playbuttonscript : MonoBehaviour {

    // Use this for initialization
    public GameObject b;
    public string scn; 
    void OnMouseUp()
    {
        Vector3 pos = b.transform.position;
        PlayerPrefs.SetFloat("sx", pos.x);
        PlayerPrefs.SetFloat("sy", pos.y);
        SceneManager.LoadScene(scn, LoadSceneMode.Single);
        Debug.Log("yes");
    }
}
