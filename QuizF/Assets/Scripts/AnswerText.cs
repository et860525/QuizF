using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerText : MonoBehaviour
{
    [SerializeField]
    private int textSize;

    public void SetText(string myText, Color myColor)
    {
        GetComponent<Text>().text = myText;
        GetComponent<Text>().color = myColor;
        GetComponent<Text>().fontSize = textSize;
    }
	
}
