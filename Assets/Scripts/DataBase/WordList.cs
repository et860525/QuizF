using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WordList
{
    public WordList(string jp = "", string ch = "", string type = "", int status = 0)
    {
        this.japanese = jp;
        this.chinese = ch;
        this.type = type;
        this.status = status;
    }

    public string japanese = "";
    public string chinese = "";
    public string type = "";
    public int status = 0;
}