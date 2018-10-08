using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsDataMenu : MonoBehaviour
{
    public GameObject furnitureButton;
    public GameObject animalButton;

    public UnityEngine.UI.Scrollbar scrollbar;

    public WordsDataControll wordsControll;    

    public Color rightColor;
    public Color wrongColor;

    private StringData theWords = new StringData(); //Load Json dataBase.
    private List<WordList> finalQuestion;

    private TextAsset file;

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
        finalQuestion.Clear();
        scrollbar.value = 1;
        
        if (_type == "Animal")
        {
            file = Resources.Load("Animal/AnimalDataBase") as TextAsset;
        }
        else if (_type == "Furniture")
        {
            file = Resources.Load("WordDataBase") as TextAsset;
        }

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
                        if (PlayerPrefs.GetString("LevelUsed" + _type + "4") == "Open")
                        {
                            for (int i = 0; i < theWords.Animal1.Count; i++)
                            {
                                finalQuestion.Add(theWords.Animal1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }

                            for (int i = 0; i < theWords.Animal2.Count; i++)
                            {
                                finalQuestion.Add(theWords.Animal2[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }

                        if (PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open")
                        {
                            for (int i = 0; i < theWords.Animal1.Count; i++)
                            {
                                finalQuestion.Add(theWords.Animal1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }

                        //Button interactable.
                        furnitureButton.GetComponent<Button>().interactable = true;
                        animalButton.GetComponent<Button>().interactable = false;
                        break;

                    case "Furniture":
                        if (PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open")
                        {
                            for (int i = 0; i < theWords.Furniture1.Count; i++)
                            {
                                finalQuestion.Add(theWords.Furniture1[i]);
                                Debug.Log(finalQuestion[i].chinese);
                            }
                        }

                        /*for (int i = 0; i < theWords.Furniture2.Count; i++)
                        {
                            finalQuestion.Add(theWords.Furniture2[i]);
                            Debug.Log(finalQuestion[i].chinese);
                        }*/

                        //Button interactable.
                        furnitureButton.GetComponent<Button>().interactable = false;
                        animalButton.GetComponent<Button>().interactable = true;       
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
        animalButton.GetComponent<Button>().interactable = true;
        furnitureButton.GetComponent<Button>().interactable = true;
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