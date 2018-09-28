using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsDataShow : MonoBehaviour
{
    [SerializeField]
    private Text jpString;

    [SerializeField]
    private Text chString;

    public string type;

    public void SetText(string _jpS, string _chS, string _type, Color _myColor)
    {
        jpString.text = _jpS;
        chString.text = _chS;

        jpString.color = _myColor;
        chString.color = _myColor;

        type = _type;
    }
}
