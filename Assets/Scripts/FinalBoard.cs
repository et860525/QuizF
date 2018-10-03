using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class FinalBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject BackGround;

    private int iTeam;

    public string myText;

    public Color rightColor;
    public Color wrongColor;

    public WordsDataControll wordsControll;

    public Text txtPoint;
    public Text txtPointInfo;

    public Image putSprite;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private AudioSource buttonClik;

    private StringData theWords; 

    private int maxNumber;
    private int finalNumber;
    private int average;

    private List<WordList> finalQuestion;
    private List<WordList> setWordStaut;

    public List<Sprite> finalSprites;

    private string levelType;
    private string fileName = "FinalList.json";
    private string path;
    private string explorerName;

    // Use this for initialization
    void Start ()
    {
        BackGround = GameObject.FindGameObjectWithTag("BackGround");
        BackGround.GetComponent<MoveOffset>().frezz = false;

        iTeam = PlayerPrefs.GetInt("iTeam");
        levelType = PlayerPrefs.GetString("LevelType");
        explorerName = PlayerPrefs.GetString("ExplorerName");

        buttonClik = GetComponent<AudioSource>();

        finalQuestion = new List<WordList>();
        setWordStaut = new List<WordList>();

        LoadData();
        SaveData();

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        finalNumber = PlayerPrefs.GetInt("finalNumberTemp" + levelType + iTeam.ToString(), finalNumber);
        average = PlayerPrefs.GetInt("averageTemp" + levelType + iTeam.ToString(), (int)average);

        txtPoint.text = finalNumber.ToString();
        txtPointInfo.text = "You got " + average.ToString() + " of 10";

        if (finalNumber == 10)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (finalNumber >= 5)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (finalNumber >= 3)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        //SaveData(iTeam);
    }


    public void ReStart()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Level" + iTeam.ToString());
    }

    void LoadData()
    {
        StreamReader path = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, fileName));
        Debug.Log(path);
        string loadJson = path.ReadToEnd();
        Debug.Log(loadJson);
        path.Close();

        //新增一個物件類型為playerState的變數 loadData
        TempDataList loadData = new TempDataList();

        //使用JsonUtillty的FromJson方法將存文字轉成Json
        loadData = JsonUtility.FromJson<TempDataList>(loadJson);

        //驗證用，將sammaru的位置變更為json內紀錄的位置
        for (int i = 0; i < loadData.tempList.Count; i++)
        {
            finalQuestion.Add(loadData.tempList[i]);
            Debug.Log(finalQuestion[i].chinese);
        }
      
        maxNumber = finalQuestion.Count;

        if (finalQuestion != null)
        {
            if (levelType != "Animal")
            {
                for (int i = 0; i < finalQuestion.Count; i++)
                {
                    if (finalQuestion[i].status == 0)
                    {
                        wordsControll.GetWordString(maxNumber, levelType, finalQuestion[i].japanese, finalQuestion[i].chinese, rightColor);
                    }
                    else
                    {
                        wordsControll.GetWordString(maxNumber, levelType, finalQuestion[i].japanese, finalQuestion[i].chinese, wrongColor);
                    }
                }
            }
        }

        if (levelType == "Animal")
        {
            LoadImages();
            if (finalSprites != null)
            {
                for (int i = 0; i < finalQuestion.Count; i++)
                {
                    for (int j = 0; j < finalSprites.Count; j++)
                    {
                        if (finalQuestion[i].japanese == finalSprites[j].name)
                        {
                            if (finalQuestion[i].status == 0)
                            {
                                wordsControll.GetWordString(maxNumber, levelType, finalQuestion[i].japanese, finalQuestion[i].chinese, finalSprites[j], rightColor);
                            }
                            else
                            {
                                wordsControll.GetWordString(maxNumber, levelType, finalQuestion[i].japanese, finalQuestion[i].chinese, finalSprites[j], wrongColor);
                            }
                        }
                    }
                }
            }
        }
    }

    void SaveData()
    {
        TextAsset file = Resources.Load("WordDataBase") as TextAsset;
        try
        {
            if (file != null)
            {
                var getJsonList = new List<WordList>();

                //Get Json File.
                string contents = file.ToString();
                Debug.Log(contents);

                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                theWords = wrapper.WordData;

                //Get data.
                Debug.Log(theWords.date + "\n" + theWords.time);

                switch (levelType)
                {
                    case "Food":
                        for (int i = 0; i < theWords.Food.Count; i++)
                        {
                            getJsonList.Add(theWords.Food[i]);
                            Debug.Log(getJsonList.Count);
                            //Debug.Log(questionWords[i].chinese);
                        }
                        break;

                    case "Furniture":
                        for (int i = 0; i < theWords.Furniture.Count; i++)
                        {
                            getJsonList.Add(theWords.Furniture[i]);
                            //Debug.Log(getJsonList.Count);
                            Debug.Log(getJsonList[i].chinese);
                        }
                        break;
                }
                
                /*for(int i = 0; i < finalQuestion.Count; i++)
                {
                    if (getJsonList[i].chinese == finalQuestion[i].chinese && finalQuestion[i].status == 1)
                    {
                        getJsonList[i].status = finalQuestion[i].status;
                        Debug.Log(getJsonList[i].chinese + getJsonList[i].status);
                    }
                }

                path = "Assets/Resources/" + fileName;
                JsonWrapper saveWrapper = new JsonWrapper();            NEED UPDATE;
                wrapper.WordData = theWords;

                contents = JsonUtility.ToJson(wrapper, true);
                System.IO.File.WriteAllText(path, contents);*/

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

    void LoadImages()
    {
        // For game run (DELETE DATA Every run).
        object[] loadedIcons = Resources.LoadAll("Animal/" + explorerName, typeof(Sprite));
        //this
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            finalSprites.Add((Sprite)loadedIcons[x]);
            //Debug.Log(qSprites.Count);
        }

        // For game anwser (NOT DELETE DATA).
        //object[] loadedTemp = Resources.LoadAll("Animal/Animal2", typeof(Sprite));
       /*for (int i = 0; i < finalSprites.Count; i++)
        {
            tempList.Add(finalSprites[i].name);
        }*/
        //or this
        //loadedIcons.CopyTo (Icons,0);
    }

    public void GoTo(string nameScene)
    {
        buttonClik.Play();
        switch (levelType)
        {
            case "Food":
                SceneManager.LoadScene("FoodSelectMenu");
                break;
            case "Furniture":
                SceneManager.LoadScene("FurnitureSelectMenu");
                break;
            case "Animal":
                SceneManager.LoadScene("AnimalSelectMenu");
                break;
        }
    }

}
