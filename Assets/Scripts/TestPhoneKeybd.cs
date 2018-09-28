using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPhoneKeybd : MonoBehaviour {

    TouchScreenKeyboard kbd;
    public string stringToEdit = "Hello World";

    // Use this for initialization
    public void OpenkeyBoard () {
        kbd = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);		
	}

    public void OnGUI()
    {
        stringToEdit = GUI.TextField(new Rect(125, -118, 200, 50), stringToEdit, 30);

        if (GUI.Button(new Rect(100, 200, 200, 100), "Default"))
        {
            kbd = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
    }

    // Update is called once per frame
    void Update () {
	}
}
