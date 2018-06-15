using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FinalBoard : MonoBehaviour
{
    private int iTeam;

    public string myText;

    public Color rightColor;
    public Color wrongColor;

    public AnswerTextControl Question;
    public AnswerTextControl Answer;

    public Text txtPoint;
    public Text txtPointInfo;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int maxNumber;
    private int finalNumber;
    private int average;

    private List<WordList> finalQuestion;

    private string fileName = "WordDataBase.json";
    private string path;

    // Use this for initialization
    void Start ()
    {
        iTeam = PlayerPrefs.GetInt("iTeam");


        finalQuestion = new List<WordList>();
        LoadData();

        maxNumber = finalQuestion.Count;

        /*for (int i = 0; i < finalQuestion.Count; i++)
        {
            Debug.Log(theWords.tempList[i].status);
        }*/

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        finalNumber = PlayerPrefs.GetInt("finalNumberTemp" + iTeam.ToString(), finalNumber);
        average = PlayerPrefs.GetInt("averageTemp" + iTeam.ToString(), (int)average);

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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level" + iTeam.ToString());
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
    }

    private void Update()
    {
        if (finalQuestion != null)
        {
            for (int i = 0; i < finalQuestion.Count; i++)
            {
                if (finalQuestion[i].status == 0)
                {
                    Question.LogText(maxNumber, finalQuestion[i].japanese, rightColor);
                }
                else
                {
                    Question.LogText(maxNumber, finalQuestion[i].japanese, wrongColor);
                }
                Answer.LogText(maxNumber, finalQuestion[i].chinese, rightColor);
            }
        }
    }

    public void GoTo(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }

}
