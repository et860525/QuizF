using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsDataMenu : MonoBehaviour
{
    public GameObject[] typeButton;

    public UnityEngine.UI.Scrollbar scrollbar;

    public WordsDataControll wordsControll;    

    public Color rightColor;
    public Color wrongColor;

    private StringData theWords = new StringData(); //Load Json dataBase.
    private List<WordList> finalQuestion;

    private void Start()
    {
        finalQuestion = new List<WordList>();      
    }

    private void Update()
    {
        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit the application
                GoTo("TypeSelectMenu");
            }
        }
        //PC Test.
        /*if (Input.GetKeyDown(KeyCode.O))
        {
            // Quit the application
            GoTo("TypeSelectMenu");
        }*/
    }

    public void LoadData(string _type)
    {
        TextAsset file = Resources.Load("DataBase/" + _type + "DataBase") as TextAsset;

        finalQuestion.Clear();
        scrollbar.value = 1;

        /* OLD MOTHERFUCKER SCHOOL
        if (_type == "Animal")
        {
            file = Resources.Load("Animal/AnimalDataBase") as TextAsset;
        }
        else if (_type == "Cuisime")
        {
            file = Resources.Load("WordDataBase") as TextAsset;
        }*/

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
                switch (_type)
                {
                    case "Animal":
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.Animal1.Count; i++)
                            {
                                finalQuestion.Add(theWords.Animal1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }

                            if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "4") == "Open"*/)
                            {
                                for (int i = 0; i < theWords.Animal2.Count; i++)
                                {
                                    finalQuestion.Add(theWords.Animal2[i]);
                                    Debug.Log(finalQuestion[i].chinese);
                                }
                            }
                        }

                        //Button interactable.
                        foreach ( var button in typeButton)
                        {
                            if (button.GetComponent<Button>().name == _type)
                            {
                                button.GetComponent<Button>().interactable = false;
                            }
                            else
                            {
                                button.GetComponent<Button>().interactable = true;
                            }
                        }

                        //typeButton[0].GetComponent<Button>().interactable = false;
                        //typeButton[1].GetComponent<Button>().interactable = true;
                        
                        break;

                    case "Cuisime":
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.Cuisime1.Count; i++)
                            {
                                finalQuestion.Add(theWords.Cuisime1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.Cuisime2.Count; i++)
                            {
                                finalQuestion.Add(theWords.Cuisime2[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }

                        foreach (var button in typeButton)
                        {
                            if (button.GetComponent<Button>().name == _type)
                            {
                                button.GetComponent<Button>().interactable = false;
                            }
                            else
                            {
                                button.GetComponent<Button>().interactable = true;
                            }
                        }
                        break;
                    case "Fruit":
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.Fruit1.Count; i++)
                            {
                                finalQuestion.Add(theWords.Fruit1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.Fruit2.Count; i++)
                            {
                                finalQuestion.Add(theWords.Fruit2[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }

                        foreach (var button in typeButton)
                        {
                            if (button.GetComponent<Button>().name == _type)
                            {
                                button.GetComponent<Button>().interactable = false;
                            }
                            else
                            {
                                button.GetComponent<Button>().interactable = true;
                            }
                        }
                        break;
                    case "Meat":
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.Meat1.Count; i++)
                            {
                                finalQuestion.Add(theWords.Meat1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }
  
                        foreach (var button in typeButton)
                        {
                            if (button.GetComponent<Button>().name == _type)
                            {
                                button.GetComponent<Button>().interactable = false;
                            }
                            else
                            {
                                button.GetComponent<Button>().interactable = true;
                            }
                        }
                        break;
                    case "Vegetable":
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.Vegetable1.Count; i++)
                            {
                                finalQuestion.Add(theWords.Vegetable1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.Vegetable2.Count; i++)
                            {
                                finalQuestion.Add(theWords.Vegetable2[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }

                        foreach (var button in typeButton)
                        {
                            if (button.GetComponent<Button>().name == _type)
                            {
                                button.GetComponent<Button>().interactable = false;
                            }
                            else
                            {
                                button.GetComponent<Button>().interactable = true;
                            }
                        }
                        break;
                    case "MakeUp":
                        if (true/*PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open"*/)
                        {
                            for (int i = 0; i < theWords.MakeUp1.Count; i++)
                            {
                                finalQuestion.Add(theWords.MakeUp1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }

                        foreach (var button in typeButton)
                        {
                            if (button.GetComponent<Button>().name == _type)
                            {
                                button.GetComponent<Button>().interactable = false;
                            }
                            else
                            {
                                button.GetComponent<Button>().interactable = true;
                            }
                        }
                        break;
                }

                wordsControll.DataBaseGetWords(finalQuestion, _type, finalQuestion.Count - 1, rightColor);


                //Debug.Log(finalQuestion.Count);

                /*if (PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open")
                {
                    lastNumber = 10;

                    if (PlayerPrefs.GetString("LevelUsed" + _type + "2") == "Open")
                    {
                        lastNumber = 20;
                    }

                    Debug.Log(lastNumber);
                }
                else
                {
                    lastNumber = 0;
                }*/



                // Very important is (WORDS NUMBER NEED SAME) solve
                /* if (finalQuestion != null)
                 {                                         
                     for (int i = 0; i < lastNumber; i++)
                     {
                         if (finalQuestion[i].status == 0)
                         {
                             wordsControll.GetWordString(lastNumber, _type, finalQuestion[i].japanese, finalQuestion[i].chinese, rightColor);
                         }
                         else
                         {
                             wordsControll.GetWordString(lastNumber, _type, finalQuestion[i].japanese, finalQuestion[i].chinese, wrongColor);
                         }
                     }
                 }*/
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


    public void GoTo(string nameScene)
    {
        typeButton[0].GetComponent<Button>().interactable = true;
        typeButton[1].GetComponent<Button>().interactable = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }

    public void SetInteractable(int finalNumber)
    {
        if (finalNumber >= 5)
        {
            //InteractableButton.GetComponent<Button>().interactable = true;
        }
    }

}