using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour {

    public GameObject msg, sc, hsc; 
	void Start () {
        msg.GetComponent<TextMeshProUGUI>().text = "Your Comet\n" + PlayerPrefs.GetString("gg");
        sc.GetComponent<TextMeshProUGUI>().text = "Score: " + PlayerPrefs.GetInt("sc");
        hsc.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("hsc");

    }
	
}
