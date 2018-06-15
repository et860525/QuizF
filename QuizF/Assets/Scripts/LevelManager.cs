using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int iTeam;

    [SerializeField]
    private GameObject BackGround;

    [SerializeField]
    private GameObject TempPanel;

    [SerializeField]
    private GameObject OutPopUp;

    [SerializeField]
    private Text qText;

    [SerializeField]
    private Text qPoint;

    [SerializeField]
    private Text timeText;

    [SerializeField]
    private Text answerTextA;

    [SerializeField]
    private Text answerTextB;

    [SerializeField]
    private Text answerTextC;

    [SerializeField]
    private Text answerTextD;

    [SerializeField]
    private int setQuestions;

    //Class
    private StringData theWords = new StringData(); //Load Json dataBase.
    private List<WordList> questionWords; //Store words.
    private List<WordList> AnswerWords; //Store answer words.
    private List<WordList> finalCorrentList; //Store corrent answer and save.

    //Static
    private static float maxTime = 11; // 11 is Invok will delay.
    private static string gameModeString; // set mode is jp -> ch or ch -> jp.

    //Intger
    private int idQuestion; // set question number.
    private int finalNumber; // set final point.
    private int answerListNum; // If answer is wrong and change Words status.

    //Float
    private float setTime; // set time.
    private float clicks; // Right answer and caculate point.
    private float maxQuestion; 
    private float average;

    //String
    private string correct;
    private string fileName = "WordDataBase.json";
    private string path;

    //Bool
    private bool isOutPopUp;

    private void Start()
    {
        Time.timeScale = 1;

        //Get Level Information
        iTeam = PlayerPrefs.GetInt("iTeam");
        gameModeString = PlayerPrefs.GetString("gameMode");

        questionWords = new List<WordList>();
        finalCorrentList = new List<WordList>();
        
        answerListNum = 0;
        setTime = maxTime;
        maxQuestion = setQuestions;
        idQuestion = 0;

        InvokeRepeating("TimerDownCount", 0f, 1f);
        
        LoadData(iTeam);

        SetQuestion(gameModeString, iTeam);

        qPoint.text = (idQuestion + 1).ToString() + "/" + maxQuestion.ToString();
    }

    void TimerDownCount()
    {
        setTime -= 1;
        timeText.text = "Time: " + Mathf.Round(setTime);
        if (setTime <= 0 )
        {
            CancelInvoke("TimerDownCount");
            BackGround.GetComponent<MoveOffset>().frezz = true;
            TempPanel.gameObject.SetActive(true);
            finalCorrentList[answerListNum].status = 1;
            StartCoroutine(Wait()); 
        }
    }

    /*private void Update()
    {
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(setTime);
        }
        else
        {
            NextQuestion(iTeam);
        }
    }*/ // NO stop time;

    void LoadData(int iTeam)
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
                switch (iTeam)
                {
                    case 1:
                        for (int i = 0; i <= theWords.Animal.Count - 1; i++)
                        {
                            questionWords.Add(theWords.Animal[i]);
                            Debug.Log(questionWords[i].japanese);
                        }
                        break;
                    case 2:
                        for (int i = 0; i <= theWords.Furniture.Count - 1; i++)
                        {
                            questionWords.Add(theWords.Furniture[i]);
                            Debug.Log(questionWords[i].chinese);
                        }
                        break;
                }

                //To array to array.
                /*for (int i = 0; i <= theWords.theWords.Count - 1; i++)
                {
                    questionWords[i] = theWords.theWords[i].word;
                    Debug.Log(questionWords[i]);
                }*/

                /*foreach (WordList w in theWords.theWords)
                {
                    Debug.Log(w.word);
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

    void SetQuestion(string gameModeString, int iTeam)
    {       
        int randomQuestionIndex = Random.Range(0, questionWords.Count);
        int randomCorrent = Random.Range(1, 4);

        //Debug.Log(randomQuestionIndex);

        switch (gameModeString)
        {
            case "jp":
                qText.text = questionWords[randomQuestionIndex].japanese;
                correct = questionWords[randomQuestionIndex].chinese;
                finalCorrentList.Add(questionWords[randomQuestionIndex]);
                questionWords.RemoveAt(randomQuestionIndex);
                break;
            case "ch":
                qText.text = questionWords[randomQuestionIndex].chinese;
                correct = questionWords[randomQuestionIndex].japanese;
                finalCorrentList.Add(questionWords[randomQuestionIndex]);
                questionWords.RemoveAt(randomQuestionIndex);
                break;
        }

        switch (randomCorrent)
        {
            case 1:
                answerTextA.text = correct;
                SetAnswer(iTeam, answerTextA, answerTextB, answerTextC, answerTextD);
                break;
            case 2:
                answerTextB.text = correct;
                SetAnswer(iTeam, answerTextB, answerTextA, answerTextC, answerTextD);
                break;
            case 3:
                answerTextC.text = correct;
                SetAnswer(iTeam, answerTextC, answerTextA, answerTextB, answerTextD);
                break;
            case 4:
                answerTextD.text = correct;
                SetAnswer(iTeam, answerTextD, answerTextA, answerTextB, answerTextC);
                break;
        }
    }

    void SetAnswer(int iTeam, Text _corrent, Text _an1, Text _an2, Text _an3)
    {
        var tempList = new List<WordList>();
        int[] tempRnd = RandomTest();

        switch (iTeam)
        {
            case 1:
                for (int i = 0; i < setQuestions; i++)
                {
                    tempList.Add(theWords.Animal[i]);
                }

                for (int i = 0; i < tempList.Count; i++)
                {
                    if (tempList[i].chinese == _corrent.text)
                    {
                        tempList.RemoveAt(i);
                    }
                }
                break;

            case 2:
                for (int i = 0; i < setQuestions; i++)
                {
                    tempList.Add(theWords.Furniture[i]);
                    //Debug.Log(tempList[i].japanese);
                }

                for (int i = 0; i < tempList.Count; i++)
                {
                    if (tempList[i].japanese == _corrent.text)
                    {
                        tempList.RemoveAt(i);
                    }
                    //Debug.Log(tempList[i].japanese);
                }

                break;
        }

        switch (gameModeString)
        {
            case "jp":
                for (int i = 0; i < setQuestions; i++)
                {
                    tempList.Add(theWords.Animal[i]);
                }

                for (int i = 0; i < tempList.Count; i++)
                {
                    if (tempList[i].chinese == _corrent.text)
                    {
                        tempList.RemoveAt(i);
                    }
                }

                _an1.text = tempList[tempRnd[0]].chinese;
                _an2.text = tempList[tempRnd[1]].chinese;
                _an3.text = tempList[tempRnd[2]].chinese;

                /*for (int i = 0; i < 3; i++)
                {
                    Debug.Log("TempRnd Value" + tempList[i]);
                }*/
                break;

            case "ch":
                Debug.Log(setQuestions);
                for (int i = 0; i < setQuestions; i++)
                {
                    tempList.Add(theWords.Furniture[i]);
                    //Debug.Log(tempList[i].japanese);
                }

                for (int i = 0; i < tempList.Count; i++)
                {
                    if (tempList[i].japanese == _corrent.text)
                    {
                        tempList.RemoveAt(i);
                    }
                    //Debug.Log(tempList[i].japanese);
                }

                _an1.text = tempList[tempRnd[0]].japanese;
                _an2.text = tempList[tempRnd[1]].japanese;
                _an3.text = tempList[tempRnd[2]].japanese;
                break;
        }

        // Debug.Log( " and " + an2 + " and " + an3);
    }

    public void CorrectAnswer(string sub)
    {
        if (sub == "A")
        {
            if (answerTextA.text == correct)
            {
                clicks += 1;
            }
            else
            {
                finalCorrentList[answerListNum].status = 1;
            }
        }

        else if (sub == "B")
        {
            if (answerTextB.text == correct)
            {
                clicks += 1;
            }
            else
            {
                finalCorrentList[answerListNum].status = 1;
            }
        }

        else if (sub == "C")
        {
            if (answerTextC.text == correct)
            {
                clicks += 1;
            }
            else
            {
                finalCorrentList[answerListNum].status = 1;
            }
        }

        else if (sub == "D")
        {
            if (answerTextD.text == correct)
            {
                clicks += 1;
            }
            else
            {
                finalCorrentList[answerListNum].status = 1;
            }
        }
        CancelInvoke("TimerDownCount");
        //NextQuestion(iTeam);
        TempPanel.gameObject.SetActive(true);
        BackGround.GetComponent<MoveOffset>().frezz = true;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        TempPanel.gameObject.SetActive(false);
        NextQuestion(iTeam);
    }

    void SaveData()
    {
        //theWords.tempList.Clear();
        
        TempDataList tempDataList = new TempDataList();

        for (int i = 0; i < finalCorrentList.Count; i++)
        {
            WordList tempList = new WordList();
            tempList.chinese = finalCorrentList[i].chinese;
            tempList.japanese = finalCorrentList[i].japanese;
            tempList.status = finalCorrentList[i].status;

            tempDataList.tempList.Add(tempList);
        }

        string contents = JsonUtility.ToJson(tempDataList, true);

        StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, fileName));
        file.Write(contents);
        file.Close();

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif

        Debug.Log("SAVE");

    }    

    void NextQuestion(int iTeam)
    {       
        idQuestion += 1;
        answerListNum += 1;

        if (idQuestion <= (maxQuestion - 1))
        {
            
            setTime = maxTime;
            InvokeRepeating("TimerDownCount", 0f, 1.0f);
            BackGround.GetComponent<MoveOffset>().frezz = false;

            SetQuestion(gameModeString, iTeam);
            qPoint.text = (idQuestion + 1).ToString() + "/" + maxQuestion.ToString();
        }
        else
        {
            SaveData();
            average = 10 * (clicks / maxQuestion);
            finalNumber = Mathf.RoundToInt(average);
            //Debug.Log(finalNumber);

            if (finalNumber >= PlayerPrefs.GetInt("finalNumber" + iTeam.ToString()))
            {
                PlayerPrefs.SetInt("finalNumber" + iTeam.ToString(), finalNumber);
                PlayerPrefs.SetInt("average" + iTeam.ToString(), (int)average);
            }

            PlayerPrefs.SetInt("finalNumberTemp" + iTeam.ToString(), finalNumber);
            PlayerPrefs.SetInt("averageTemp" + iTeam.ToString(), (int)average);

            SceneManager.LoadScene("FinalBoard");
        }
    } 

    private int[] RandomTest()
    {
        int[] randomArray = new int[3]; // This array is answers.
        System.Random rnd = new System.Random();
        for (int i = 0; i < 3; i++)
        {
            randomArray[i] = rnd.Next(0, setQuestions - 1);   // Random 1 ~ List.Count.

            //Debug.Log("TempRnd Value" + randomArray[i]);
            

            for (int j = 0; j < i; j++)
            {
                while (randomArray[j] == randomArray[i])    // Check match or not.
                {
                    j = 0;  // If match j = 0 do again.
                    randomArray[i] = rnd.Next(0, setQuestions - 1);   // Random 1 ~ List.Count.
                }
            }
        }
        return randomArray;
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
        SceneManager.LoadScene("SelectMenu");
    }
}
