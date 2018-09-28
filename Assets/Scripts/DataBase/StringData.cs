using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringData
{
    public string date = "";
    public string time = "";

    //Chose word type;
    public List<WordList> Food = new List<WordList>();
    public List<WordList> Furniture = new List<WordList>();
    
    //public List<WordList> tempList = new List<WordList>();
}
