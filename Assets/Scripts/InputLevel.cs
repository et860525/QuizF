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
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
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
        switch (levelType)
        {
            case "Animal":
                SaveData();
                SceneManager.LoadScene("AnimalSelectMenu");
                break;
            case "Cuisime":
                SaveData();
                SceneManager.LoadScene("CuisimeSelectMenu");
                break;
            case "Fruit":
                SaveData();
                SceneManager.LoadScene("FruitSelectMenu");
                break;
            case "Meat":
                SaveData();
                SceneManager.LoadScene("MeatSelectMenu");
                break;
            case "Vegetable":
                SaveData();
                SceneManager.LoadScene("VegetableSelectMenu");
                break;
        }
    }
}
