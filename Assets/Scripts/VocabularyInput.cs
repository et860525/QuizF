using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class VocabularyInput : MonoBehaviour {

    private StringData theWords = new StringData(); //Load Json dataBase.
    private List<WordList> saveList;
    public Dropdown dropdownType;
    public Text selectedName;
    public Button enterButton;
    public InputField Jp;
    public InputField Ch;

    List<string> names = new List<string>() { "Select type", "Furniture1", "Furniture2", "Animal1", "Animal2", "Animal3" };

    private void Start()
    {
        saveList = new List<WordList>();
        TypeList();
    }

    void TypeList()
    {
        dropdownType.AddOptions(names);
    }


    public void Dropdown_IndexChanged(int index)
    {
        if (index > 0)
        {
            enterButton.interactable = true;
        }
        else
        {
            enterButton.interactable = false;
        }
        selectedName.text = names[index];
        LoadData(index);
    }

    void LoadData(int _leveltype)
    {
        TextAsset file = Resources.Load("Animal/AnimalDataBase") as TextAsset;
         
        try
        {
            if (file != null)
            {
                //Get Json File.
                string contents = file.ToString();
                Debug.Log(contents);

                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                theWords = wrapper.WordData;

                //Get data.
                Debug.Log(theWords.date + "\n" + theWords.time);

                switch (_leveltype)
                {
                    case 1:
                        for (int i = 0; i < theWords.Furniture1.Count; i++)
                        {
                            saveList.Add(theWords.Furniture1[i]);
                            //Debug.Log(getJsonList.Count);
                            //Debug.Log(saveList[i].chinese);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < theWords.Furniture2.Count; i++)
                        {
                            saveList.Add(theWords.Furniture2[i]);
                            //Debug.Log(getJsonList.Count);
                            //Debug.Log(saveList[i].chinese);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < theWords.Animal1.Count; i++)
                        {
                            saveList.Add(theWords.Animal1[i]);
                            //Debug.Log(getJsonList.Count);
                            //Debug.Log(saveList[i].chinese);
                        }
                        break;
                    case 4:
                        for (int i = 0; i < theWords.Animal2.Count; i++)
                        {
                            saveList.Add(theWords.Animal2[i]);
                            //Debug.Log(getJsonList.Count);
                            //Debug.Log(saveList[i].chinese);
                        }
                        break;
                    case 5:
                        for (int i = 0; i < theWords.Animal3.Count; i++)
                        {
                            saveList.Add(theWords.Animal3[i]);
                            //Debug.Log(getJsonList.Count);
                            //Debug.Log(saveList[i].chinese);
                        }
                        break;
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

    public void EnterAnswer()
    {
        switch(selectedName.text)
        {
            case "Animal1":
                theWords.Animal1.Add(new WordList(Jp.text, Ch.text, "Animal"));
                break;
            case "Animal2":
                theWords.Animal2.Add(new WordList(Jp.text, Ch.text, "Animal"));
                break;
            case "Animal3":
                theWords.Animal3.Add(new WordList(Jp.text, Ch.text, "Animal"));
                break;
        }            
        SaveData(selectedName.text);
        Jp.text = "";
        Ch.text = "";
    }

    void SaveData(string type)
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.WordData = theWords;

        string contents = JsonUtility.ToJson(wrapper, true);
        if (type == "Animal1" || type == "Animal2" || type == "Animal3")
        {
            System.IO.File.WriteAllText("Assets/Resources/Animal/AnimalDataBase.json", contents);
        }
        else
        {
            System.IO.File.WriteAllText("Assets/Resources/WordDataBase.json", contents);
        }

    }


}
