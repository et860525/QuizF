using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsDataMenu : MonoBehaviour
{
    public GameObject foodButton;
    public GameObject furnitureButton;

    public UnityEngine.UI.Scrollbar scrollbar;

    public WordsDataControll wordsControll;    

    public Color rightColor;
    public Color wrongColor;

    private StringData theWords = new StringData(); //Load Json dataBase.
    private List<WordList> finalQuestion;

    private int maxNumber;    
    private int lastNumber;

    private string levelUsed;

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
        if (Input.GetKeyDown(KeyCode.O))
        {
            // Quit the application
            GoTo("TypeSelectMenu");
        }
    }

    public void LoadData(string _type)
    {
        finalQuestion.Clear();
        lastNumber = 0;
        scrollbar.value = 1;

        TextAsset file = Resources.Load("WordDataBase") as TextAsset;
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
                    case "Food":
                        for (int i = 0; i < theWords.Food.Count; i++) //Must Load all json file of type.
                        {
                            finalQuestion.Add(theWords.Food[i]);
                            Debug.Log(finalQuestion[i].chinese);
                        }

                        //Button interactable.
                        foodButton.GetComponent<Button>().interactable = false;
                        furnitureButton.GetComponent<Button>().interactable = true;
                        break;
                    case "Furniture":
                        for (int i = 0; i < theWords.Furniture.Count; i++)
                        {
                            finalQuestion.Add(theWords.Furniture[i]);
                            Debug.Log(finalQuestion[i].chinese);
                        }

                        //Button interactable.
                        furnitureButton.GetComponent<Button>().interactable = false;
                        foodButton.GetComponent<Button>().interactable = true;                       
                        break;
                }

                if (PlayerPrefs.GetString("LevelUsed" + _type + "1") == "Open")
                {
                    lastNumber = 9;

                    if (PlayerPrefs.GetString("LevelUsed" + _type + "2") == "Open")
                    {
                        lastNumber = 19;
                    }

                    Debug.Log(lastNumber);
                }
                else
                {
                    lastNumber = 0;
                }

                Debug.Log(lastNumber);

                wordsControll.DataBaseGetWords(finalQuestion, _type, lastNumber, rightColor);


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
        foodButton.GetComponent<Button>().interactable = true;
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