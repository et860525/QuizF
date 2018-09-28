using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class VocabularyInput : MonoBehaviour {

    private string fileName = "WordDataBase.json";
    private StringData theWords = new StringData(); //Load Json dataBase.
    private List<WordList> saveList;
    public Dropdown dropdownType;
    public Text selectedName;
    public Button enterButton;
    public InputField Jp;
    public InputField Ch;

    List<string> names = new List<string>() { "Select type", "Food", "Furniture" };

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
        TextAsset file = Resources.Load("WordDataBase") as TextAsset;
        //string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        //string filePath = Path.Combine(Application.dataPath, fileName);        
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
                        for (int i = 0; i < theWords.Food.Count; i++)
                        {
                            saveList.Add(theWords.Food[i]);
                            //Debug.Log(getJsonList.Count);
                            //Debug.Log(saveList[i].chinese);
                        }
                        break;

                    case 2:
                        for (int i = 0; i < theWords.Furniture.Count; i++)
                        {
                            saveList.Add(theWords.Furniture[i]);
                            //Debug.Log(getJsonList.Count);
                            //Debug.Log(saveList[i].chinese);
                        }
                        break;
                        //.....ADD TYPE.
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
            case "Food":
                theWords.Food.Add(new WordList(Jp.text, Ch.text, selectedName.text));
                break;
            case "Furniture":
                theWords.Furniture.Add(new WordList(Jp.text, Ch.text, selectedName.text));
                break;
        }            
        SaveData();
    }

    void SaveData()
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.WordData = theWords;

        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText("Assets/Resources/WordDataBase.json", contents);

    }


}
