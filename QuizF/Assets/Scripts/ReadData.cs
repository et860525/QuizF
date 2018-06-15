using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    string filename = "WordDataBase.json";
    string path;

    StringData theWords = new StringData();

    // Use this for initialization
    void Start()
    {
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            theWords.date = System.DateTime.Now.ToShortDateString();
            theWords.time = System.DateTime.Now.ToShortTimeString();

            WordList w1 = new WordList();
            w1.word = "Cow";
            w1.anwser = "牛";
            theWords.Animal.Add(w1);

            SaveData();
        }*/

        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (WordList w in theWords.Animal)
            {
                Debug.Log(w.chinese);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadData();
        }
    }

    void SaveData()
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.WordData = theWords;

        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(path, contents);
    }

    void LoadData()
    {
        try
        {
            if (System.IO.File.Exists(path))
            {
                string contents = System.IO.File.ReadAllText(path);
                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                theWords = wrapper.WordData;
                Debug.Log(theWords.date + "\n" + theWords.time);

                foreach (WordList w in theWords.Animal)
                {
                    Debug.Log(w.chinese);
                }
            }
            else
            {
                Debug.Log("Unable to read the save data, file does not exist.");
            }

        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

}
