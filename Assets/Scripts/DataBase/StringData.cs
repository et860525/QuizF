using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringData
{
    public string date = "";
    public string time = "";

    //Chose word type;
    public List<WordList> Furniture1 = new List<WordList>();
    public List<WordList> Furniture2 = new List<WordList>();
    public List<WordList> Animal1 = new List<WordList>();
    public List<WordList> Animal2 = new List<WordList>();
    public List<WordList> Animal3 = new List<WordList>();

    //public List<WordList> tempList = new List<WordList>();
}
