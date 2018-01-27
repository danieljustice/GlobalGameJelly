using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {
    Text UiText;
    string debugText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UiText.text = debugText;

    }
    public void DebugMessage(string txtMessage)
    {
        debugText = txtMessage;
    }
}
