using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringData
{
    public string date = "";
    public string time = "";

    //Chose word type;
    public List<WordList> Animal1 = new List<WordList>();
    public List<WordList> Animal2 = new List<WordList>();
    public List<WordList> Animal3 = new List<WordList>();

    public List<WordList> Cuisime1 = new List<WordList>();
    public List<WordList> Cuisime2 = new List<WordList>();

    public List<WordList> Fruit1 = new List<WordList>();
    public List<WordList> Fruit2 = new List<WordList>();

    public List<WordList> Meat1 = new List<WordList>();

    public List<WordList> Vegetable1 = new List<WordList>();
    public List<WordList> Vegetable2 = new List<WordList>();

    public List<WordList> MakeUp1 = new List<WordList>();

}
