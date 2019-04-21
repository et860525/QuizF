using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class InputLevel : MonoBehaviour
{
    public List<GameObject> answerInput;
    public GameObject OutPopUp;
    public GameObject WinPanel;

    public List<string> tempListString = new List<string>();
    private OnlyStringData loadData = new OnlyStringData();

    public AudioSource audioPlay = new AudioSource();

    private string levelType;
    private string levelName;
    private string fileName = "OnlyString.json";

    private int iTeam;  
    private int finalNumber;

    private float checkAll;
    private float crrect;
    private float average;

    private static float thePoint;

    private bool isOutPopUp;

    private void Start()
    {
        //Screen.fullScreen = false;
        checkAll = 0;
        iTeam = PlayerPrefs.GetInt("iTeam");
        levelType = PlayerPrefs.GetString("LevelType");
        levelName = PlayerPrefs.GetString("LevelID");
        thePoint = answerInput.Count;
        CheckFile();
        LoadData(levelName);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit the application
                CallOutPopUp();
            }
        }
        /*if (Input.GetKeyDown(KeyCode.O))
        {
            // Quit the application
            CallOutPopUp();
        }*/
    }

    void CheckFile()
    {
        string filePath = Application.persistentDataPath + "/" + fileName;
        if (!File.Exists(filePath))
        {
            string contents = JsonUtility.ToJson(loadData, true);

            StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, fileName));
            Debug.Log(file.ToString());
            file.Write(contents);
            file.Close();


#if UNITY_EDITOR && UNITY_ANDROID
            UnityEditor.AssetDatabase.Refresh();
#endif

            Debug.Log("SAVE");
        }
    }

    void LoadData(string _levelName)
    {
        StreamReader path = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, fileName));
        Debug.Log(Application.persistentDataPath);
        //Debug.Log(path);
        string loadJson = path.ReadToEnd();
        Debug.Log(loadJson);
        path.Close();

        //新增一個物件類型為playerState的變數 loadData
        //OnlyStringData loadData = new OnlyStringData();

        //使用JsonUtillty的FromJson方法將存文字轉成Json
        loadData = JsonUtility.FromJson<OnlyStringData>(loadJson);

        //驗證用，將sammaru的位置變更為json內紀錄的位置

        switch (_levelName)
        {
            //****************Animal****************
            case "Animal1":
                if (loadData.Animal1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Animal1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Animal1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");                       
                    }
                }
                break;
            case "Animal2":
                if (loadData.Animal2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Animal2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Animal2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Animal3":
                if (loadData.Animal3_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Animal3_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Animal3_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;

            //************************Cuisime********************************
            case "Cuisime1":
                if (loadData.Cuisime1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Cuisime1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Cuisime1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Cuisime2":
                if (loadData.Cuisime2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Cuisime2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Cuisime2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;

            //************************Fruit********************************
            case "Fruit1":
                if (loadData.Fruit1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Fruit1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Fruit1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Fruit2":
                if (loadData.Fruit2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Fruit2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Fruit2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;

            //************************Meat********************************
            case "Meat1":
                if (loadData.Meat1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Meat1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Meat1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;

            //************************Vegetable********************************
            case "Vegetable1":
                if (loadData.Vegetable1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Vegetable1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Vegetable1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Vegetable2":
                if (loadData.Vegetable2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Vegetable2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Vegetable2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;

            //************************MakeUp********************************
            case "MakeUp1":
                if (loadData.MakeUp1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.MakeUp1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.MakeUp1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Position********************************
            case "Position1":
                if (loadData.Position1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Position1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Position1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Position2":
                if (loadData.Position1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Position2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Position2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Position3":
                if (loadData.Position3_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Position3_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Position3_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************EleProducts********************************
            case "EleProducts1":
                if (loadData.EleProducts1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.EleProducts1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.EleProducts1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Family********************************
            case "Family1":
                if (loadData.Family1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Family1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Family1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Transport********************************
            case "Transport1":
                if (loadData.Transport1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Transport1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Transport1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Festival********************************
            case "Festival1":
                if (loadData.Festival1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Festival1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Festival1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Subject********************************
            case "Subject1":
                if (loadData.Subject1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Subject1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Subject1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************CuisimeStyle********************************
            case "CuisimeStyle1":
                if (loadData.CuisimeStyle1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.CuisimeStyle1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.CuisimeStyle1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Hair********************************
            case "Hair1":
                if (loadData.Hair1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Hair1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Hair1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Fitting********************************
            case "Fitting1":
                if (loadData.Fitting1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Fitting1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Fitting1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Weather********************************
            case "Weather1":
                if (loadData.Weather1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Weather1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Weather1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Stationery********************************
            case "Stationery1":
                if (loadData.Stationery1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Stationery1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Stationery1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Clothes********************************
            case "Clothes1":
                if (loadData.Clothes1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Clothes1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Clothes1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Shoes********************************
            case "Shoes1":
                if (loadData.Shoes1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Shoes1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Shoes1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Colors********************************
            case "Colors1":
                if (loadData.Colors1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Colors1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Colors1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Disaster********************************
            case "Disaster1":
                if (loadData.Disaster1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Disaster1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Disaster1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Beverage********************************
            case "Beverage1":
                if (loadData.Beverage1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Beverage1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Beverage1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Facility********************************
            case "Facility1":
                if (loadData.Facility1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Facility1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Facility1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Plant********************************
            case "Plant1":
                if (loadData.Plant1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Plant1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Plant1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Career********************************
            case "Career1":
                if (loadData.Career1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Career1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Career1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Career2":
                if (loadData.Career2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Career2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Career2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Body********************************
            case "Body1":
                if (loadData.Body1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Body1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Body1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Body2":
                if (loadData.Body2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Body2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Body2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Sport********************************
            case "Sport1":
                if (loadData.Sport1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Sport1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Sport1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Sport2":
                if (loadData.Sport2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Sport2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Sport2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Contry********************************
            case "Contry1":
                if (loadData.Contry1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Contry1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Contry1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Contry2":
                if (loadData.Contry2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Contry2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Contry2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            //************************Furniture********************************
            case "Furniture1":
                if (loadData.Furniture1_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Furniture1_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Furniture1_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
            case "Furniture2":
                if (loadData.Furniture2_Temp.Count != 0)
                {
                    for (int i = 0; i < loadData.Furniture2_Temp.Count; i++)
                    {
                        tempListString.Add(loadData.Furniture2_Temp[i]);
                        //Debug.Log(tempListString[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < answerInput.Count; i++)
                    {
                        tempListString.Add("");
                    }
                }
                break;
        }
        for ( int i = 0; i < answerInput.Count; i++)
        {
            if (tempListString[i] != null)
            {
                answerInput[i].GetComponent<InputField>().text = tempListString[i];
                GetAnswerInt(i);
            }
        }
    }

    void SaveData()
    {
        //theWords.tempList.Clear();
        //OnlyStringData loadData = new OnlyStringData();
      
        switch (levelName)
        {
            //************************Animal********************************
            case "Animal1":
                loadData.Animal1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Animal1_Temp.Add(tempListString[i]);
                }
                break;
            case "Animal2":
                loadData.Animal2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Animal2_Temp.Add(tempListString[i]);
                }
                break;
            case "Animal3":
                loadData.Animal3_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Animal3_Temp.Add(tempListString[i]);
                }
                break;
            //************************Cuisime********************************
            case "Cuisime1":
                loadData.Cuisime1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Cuisime1_Temp.Add(tempListString[i]);
                }
                break;
            case "Cuisime2":
                loadData.Cuisime2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Cuisime2_Temp.Add(tempListString[i]);
                }
                break;

            //************************Fruit********************************
            case "Fruit1":
                loadData.Fruit1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Fruit1_Temp.Add(tempListString[i]);
                }
                break;
            case "Fruit2":
                loadData.Fruit2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Fruit2_Temp.Add(tempListString[i]);
                }
                break;

            //************************Meat********************************
            case "Meat1":
                loadData.Meat1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Meat1_Temp.Add(tempListString[i]);
                }
                break;

            //************************Vegetable********************************
            case "Vegetable1":
                loadData.Vegetable1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Vegetable1_Temp.Add(tempListString[i]);
                }
                break;
            case "Vegetable2":
                loadData.Vegetable1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Vegetable2_Temp.Add(tempListString[i]);
                }
                break;
            //************************MakeUp********************************
            case "MakeUp1":
                loadData.MakeUp1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.MakeUp1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Position********************************
            case "Position1":
                loadData.Position1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Position1_Temp.Add(tempListString[i]);
                }
                break;
            case "Position2":
                loadData.Position2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Position2_Temp.Add(tempListString[i]);
                }
                break;
            case "Position3":
                loadData.Position3_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Position3_Temp.Add(tempListString[i]);
                }
                break;
            //************************EleProducts********************************
            case "EleProducts1":
                loadData.EleProducts1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.EleProducts1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Family********************************
            case "Family1":
                loadData.Family1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Family1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Transport********************************
            case "Transport1":
                loadData.Transport1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Transport1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Festival********************************
            case "Festival1":
                loadData.Festival1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Festival1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Subject********************************
            case "Subject1":
                loadData.Subject1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Subject1_Temp.Add(tempListString[i]);
                }
                break;
            //************************CuisimeStyle********************************
            case "CuisimeStyle1":
                loadData.CuisimeStyle1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.CuisimeStyle1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Hair********************************
            case "Hair1":
                loadData.Hair1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Hair1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Fitting********************************
            case "Fitting1":
                loadData.Fitting1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Fitting1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Weather********************************
            case "Weather1":
                loadData.Weather1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Weather1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Stationery********************************
            case "Stationery1":
                loadData.Stationery1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Stationery1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Clothes********************************
            case "Clothes1":
                loadData.Clothes1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Clothes1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Shoes********************************
            case "Shoes1":
                loadData.Shoes1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Shoes1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Colors********************************
            case "Colors1":
                loadData.Colors1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Colors1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Disaster********************************
            case "Disaster1":
                loadData.Disaster1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Disaster1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Beverage********************************
            case "Beverage1":
                loadData.Beverage1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Beverage1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Facility********************************
            case "Facility1":
                loadData.Facility1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Facility1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Plant********************************
            case "Plant1":
                loadData.Plant1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Plant1_Temp.Add(tempListString[i]);
                }
                break;
            //************************Career********************************
            case "Career1":
                loadData.Career1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Career1_Temp.Add(tempListString[i]);
                }
                break;
            case "Career2":
                loadData.Career2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Career2_Temp.Add(tempListString[i]);
                }
                break;
            //************************Body********************************
            case "Body1":
                loadData.Body1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Body1_Temp.Add(tempListString[i]);
                }
                break;
            case "Body2":
                loadData.Body2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Body2_Temp.Add(tempListString[i]);
                }
                break;
            //************************Sport********************************
            case "Sport1":
                loadData.Sport1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Sport1_Temp.Add(tempListString[i]);
                }
                break;
            case "Sport2":
                loadData.Sport2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Sport2_Temp.Add(tempListString[i]);
                }
                break;
            //************************Contry********************************
            case "Contry1":
                loadData.Contry1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Contry1_Temp.Add(tempListString[i]);
                }
                break;
            case "Contry2":
                loadData.Contry2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Contry2_Temp.Add(tempListString[i]);
                }
                break;
            //************************Furniture********************************
            case "Furniture1":
                loadData.Furniture1_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Furniture1_Temp.Add(tempListString[i]);
                }
                break;
            case "Furniture2":
                loadData.Furniture2_Temp.Clear();
                for (int i = 0; i < answerInput.Count; i++)
                {
                    loadData.Furniture2_Temp.Add(tempListString[i]);
                }
                break;
        }

        string contents = JsonUtility.ToJson(loadData, true);

        StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, fileName));
        Debug.Log(file.ToString());
        file.Write(contents);
        file.Close();


#if UNITY_EDITOR && UNITY_ANDROID
        UnityEditor.AssetDatabase.Refresh();
#endif

        Debug.Log("SAVE");

    }

    public void AudioToPlay(AudioClip clip)
    {
        if (!audioPlay.isPlaying)
        {
            audioPlay.clip = clip;
            audioPlay.Play();
        }
    }

    public void GetAnswerInt(int i)
    {
        if (answerInput[i].GetComponent<InputField>().text == answerInput[i].name)
        {
            answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.green;
            answerInput[i].GetComponent<InputField>().interactable = false;
            checkAll++;
            crrect++;
            tempListString.RemoveAt(i);
            tempListString.Insert(i, answerInput[i].GetComponent<InputField>().text);
            //Debug.Log("Yes");
        }
        else if (answerInput[i].GetComponent<InputField>().text != answerInput[i].name && answerInput[i].GetComponent<InputField>().text != "") 
        {
            answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.red;
            //answerInput[i].GetComponent<InputField>().interactable = false;
            tempListString.RemoveAt(i);
            tempListString.Insert(i, answerInput[i].GetComponent<InputField>().text);
            //Debug.Log("No");
        }
 
        if (checkAll == answerInput.Count)
        {
            WinPanel.SetActive(true);
            WinPanel.transform.Find("Image").transform.Find("Text").GetComponent<Text>().text = "Clear";
            
            for (int n = 0; n < tempListString.Count; n++)
            {
                tempListString[n] = "";
            }
            
            average = 10 * (crrect / thePoint);
            finalNumber = Mathf.RoundToInt(average);

            if (finalNumber >= PlayerPrefs.GetInt("finalNumber" + levelType + iTeam.ToString()))
            {
                PlayerPrefs.SetInt("finalNumber" + levelType + iTeam.ToString(), finalNumber);
                PlayerPrefs.SetInt("average" + levelType + iTeam.ToString(), (int)average);
            }

            PlayerPrefs.SetInt("finalNumberTemp" + levelType + iTeam.ToString(), finalNumber);
            PlayerPrefs.SetInt("averageTemp" + levelType + iTeam.ToString(), (int)average);
        } 
    }

    public void CallOutPopUp()
    {
        isOutPopUp = !isOutPopUp;

        if (isOutPopUp)
        {
            OutPopUp.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (!isOutPopUp)
        {
            OutPopUp.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void YesOutPopUp()
    {
        SaveData();

        switch (levelType)
        {
            case "Beverage":
            case "Clothes":
            case "Colors":
            case "CuisimeStyle":
            case "Disaster":
            case "EleProducts":
            case "Facility":
            case "Family":
            case "Festival":
            case "Fitting":
            case "Hair":
            case "Plant":
            case "Shoes":
            case "Stationery":
            case "Subject":
            case "Transport":   
            case "Weather":                  
                SceneManager.LoadScene("OneListSelectMenu");
                break;
            case "Body":
            case "Career":
            case "Contry":
            case "Furniture":     
            case "Sport":
                SceneManager.LoadScene("TwoListSelectMenu");
                break;

            default:
                SceneManager.LoadScene(levelType + "SelectMenu");
                break;
        }
    }
}