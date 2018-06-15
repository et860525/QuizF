/*using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int iTeam;

    public GameObject questionPanel;

    [SerializeField]
    private Text qText;

    [SerializeField]
    private Text qPoint;

    [SerializeField]
    private Text timeText;

    [SerializeField]
    private Text answerText1;

    [SerializeField]
    private Text answerText2;

    [SerializeField]
    private Text answerText3;

    [SerializeField]
    private Text answerText4;

    [SerializeField]
    private int setQuestions;

    [SerializeField]
    private string[] answerA;

    [SerializeField]
    private string[] answerB;

    [SerializeField]
    private string[] answerC;

    [SerializeField]
    private string[] answerD;

    [SerializeField]
    private string[] correct;

    private StringData theWords = new StringData();

    private List<WordList> questionWords;

    //private enum WordType { Animal = 1, Furniture = 2};

    private static int maxTime = 10;
    private static int GameMode; // set mode is en -> ch or ch -> en.

    private int setTime; // set time.
    private int idQuestion; // set question number.
    private int finalNumber; // set final point.

    private float clicks;
    private float maxQuestion;
    private float average;

    private string fileName = "WordDataBase.json";

    private void Start()
    {
        iTeam = PlayerPrefs.GetInt("iTeam");

        questionWords = new List<WordList>();

        setTime = maxTime;
        InvokeRepeating("Time", 1f, 1f);
        idQuestion = 0;
        maxQuestion = setQuestions;

        LoadData(iTeam);

        SetQuestionMode(GameMode);

        //qText.text = answer[idQuestion];
        answerText1.text = answerA[idQuestion];
        answerText2.text = answerB[idQuestion];
        answerText3.text = answerC[idQuestion];
        answerText4.text = answerD[idQuestion];

        qPoint.text = (idQuestion + 1).ToString() + "/" + maxQuestion.ToString();
    }

    private void FixedUpdate()
    {
    }

    void Time()
    {
        setTime -= 1;
        timeText.text = "Time:" + setTime.ToString();

        if (setTime == 0)
        {
            setTime = maxTime;
            timeText.text = "Time:" + setTime.ToString();
            NextQuestion(iTeam);
        }

        //Debug.Log(setTime);
    }

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
                            GameMode = 1;
                            Debug.Log(questionWords[i].english);
                        }
                        break;
                    case 2:
                        for (int i = 0; i <= theWords.Furniture.Count - 1; i++)
                        {
                            questionWords.Add(theWords.Furniture[i]);
                            GameMode = 2;
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

    public void CorrectAnswer(string sub)
    {
        if (sub == "A")
        {
            if (answerA[idQuestion] == correct[idQuestion])
            {
                clicks += 1;
            }
        }

        else if (sub == "B")
        {
            if (answerB[idQuestion] == correct[idQuestion])
            {
                clicks += 1;
            }
        }

        else if (sub == "C")
        {
            if (answerC[idQuestion] == correct[idQuestion])
            {
                clicks += 1;
            }
        }

        else if (sub == "D")
        {
            if (answerD[idQuestion] == correct[idQuestion])
            {
                clicks += 1;
            }
        }

        NextQuestion(iTeam);

    }

    void NextQuestion(int iTeam)
    {
        idQuestion += 1;

        if (idQuestion <= (maxQuestion - 1))
        {
            SetQuestionMode(GameMode);
            answerText1.text = answerA[idQuestion];
            answerText2.text = answerB[idQuestion];
            answerText3.text = answerC[idQuestion];
            answerText4.text = answerD[idQuestion];

            qPoint.text = (idQuestion + 1).ToString() + "/" + maxQuestion.ToString();
            setTime = 10;
        }
        else
        {
            average = 10 * (clicks / maxQuestion);
            finalNumber = Mathf.RoundToInt(average);

            if (finalNumber > PlayerPrefs.GetInt("finalNumber" + idQuestion.ToString()))
            {
                PlayerPrefs.SetInt("finalNumber" + iTeam.ToString(), finalNumber);
                PlayerPrefs.SetInt("average" + iTeam.ToString(), (int)average);
            }

            PlayerPrefs.SetInt("finalNumberTemp" + iTeam.ToString(), finalNumber);
            PlayerPrefs.SetInt("averageTemp" + iTeam.ToString(), (int)average);

            SceneManager.LoadScene("FinalBoard");
        }
    }

    void SetQuestionMode(int gameMode)
    {
        int randomQuestionIndex = Random.Range(0, questionWords.Count);
        //currentQuestion = questionWords[randomQuestionIndex];

        switch (gameMode)
        {
            case 1:
                qText.text = questionWords[randomQuestionIndex].english;
                questionWords.RemoveAt(randomQuestionIndex);


                break;
            case 2:
                qText.text = questionWords[randomQuestionIndex].chinese;
                questionWords.RemoveAt(randomQuestionIndex);
                break;
        }
    }
}
*/