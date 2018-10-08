using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageLevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BackGround;

    [SerializeField]
    private GameObject TempPanel;

    [SerializeField]
    private GameObject OutPopUp;

    [SerializeField]
    private Image qImage;

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

    public List<Sprite> qSprites; // icons array

    private AudioSource timeSound;

    //Class
    private StringData theWords = new StringData(); //Load Json dataBase.
    private List<WordList> questionWords; //Store words.
    private List<WordList> AnswerWords; //Store answer words.
    private List<WordList> finalCorrentList; //Store corrent answer and save.
    private List<string> tempList;

    //Static
    private static float maxTime = 11; // Set 11 beacuse Invok will delay.

    //Intger
    private int iTeam; //Set Level.
    private int idQuestion; // Set question number.
    private int finalNumber; // Set final point.
    private int answerListNum; // If answer is wrong and change Words status.
    private int finalListCount = 0;

    //Float
    private float setTime; // Set time.
    private float clicks; // Right answer and caculate point.
    private float average; // Calculate point.
    private float maxQuestion;

    //String
    private string levelType;
    private string correct;
    private string fileName = "FinalList.json";
    private string explorerName;

    //Bool
    private bool isOutPopUp; // Controll the panel.

    /*
     * Two part: 1.Check LevelType 2.Check question is Ch or Jp 
    */
    private void Start()
    {
        tempList = new List<string>();
        finalCorrentList = new List<WordList>();
        Time.timeScale = 1;

        BackGround = GameObject.FindGameObjectWithTag("BackGround");

        //Get Level Information
        iTeam = PlayerPrefs.GetInt("iTeam");
        levelType = PlayerPrefs.GetString("LevelType");
        explorerName = PlayerPrefs.GetString("ExplorerName");

        timeSound = GetComponent<AudioSource>();

        answerListNum = 0;
        setTime = maxTime;

        InvokeRepeating("TimerDownCount", 0f, 1f);

        LoadImages();

        SetQuestion();

        idQuestion = 0;


        qPoint.text = (idQuestion + 1).ToString() + "/" + maxQuestion.ToString();
    }

    void TimerDownCount()
    {
        setTime -= 1;
        timeSound.Play();
        timeText.text = "Time: " + Mathf.Round(setTime);
        if (setTime <= 0)
        {
            CancelInvoke("TimerDownCount");
            BackGround.GetComponent<MoveOffset>().frezz = true;
            TempPanel.gameObject.SetActive(true);
            finalCorrentList[answerListNum].status = 1;
            StartCoroutine(Wait());
        }
    }
    //Array
    /*void LoadImages()
    {
        object[] loadedIcons = Resources.LoadAll("Animal/Animal1", typeof(Sprite));
        qSprites = new Sprite[loadedIcons.Length];
        //this
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            qSprites[x] = (Sprite)loadedIcons[x];
        }
        //or this
        //loadedIcons.CopyTo (Icons,0);

    }*/

    //List
    void LoadImages()
    {
        // For game run (DELETE DATA Every run).
        object[] loadedIcons = Resources.LoadAll("Animal/" + explorerName, typeof(Sprite));
        //this
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            qSprites.Add((Sprite)loadedIcons[x]);
           //Debug.Log(qSprites.Count);
        }

        maxQuestion = qSprites.Count;
        Debug.Log("max ist number " + maxQuestion);

        // For game anwser (NOT DELETE DATA).
        //object[] loadedTemp = Resources.LoadAll("Animal/Animal2", typeof(Sprite));
        for (int i = 0; i < qSprites.Count; i++)
        {
            tempList.Add(qSprites[i].name);
        }
        //or this
        //loadedIcons.CopyTo (Icons,0);
    }

    void SetQuestion()
    {
        answerTextA.color = Color.black;
        answerTextB.color = Color.black;
        answerTextC.color = Color.black;
        answerTextD.color = Color.black;

        // Random for Question
        int randomQuestionIndex = Random.Range(0, qSprites.Count); // Depend questionWords list Count (questionWords is --), and random in the questionWords question.
        // Random for Anwser
        int randomCorrent = Random.Range(1, 4);

        //Question
        qImage.sprite = qSprites[randomQuestionIndex];
        correct = qSprites[randomQuestionIndex].name;

        //Save question string for final board.           
        finalCorrentList.Add(new WordList(correct));
        //Debug.Log("Is: " + finalCorrentList[answerListNum].japanese + finalCorrentList[answerListNum].status);

        qSprites.RemoveAt(randomQuestionIndex);

        //Set Answer.
        switch (randomCorrent)  // Set correct answer.
        {
            case 1:
                answerTextA.text = correct;
                SetAnswer(answerTextA, answerTextB, answerTextC, answerTextD);
                break;
            case 2:
                answerTextB.text = correct;
                SetAnswer(answerTextB, answerTextA, answerTextC, answerTextD);
                break;
            case 3:
                answerTextC.text = correct;
                SetAnswer(answerTextC, answerTextA, answerTextB, answerTextD);
                break;
            case 4:
                answerTextD.text = correct;
                SetAnswer(answerTextD, answerTextA, answerTextB, answerTextC);
                break;
        }
    }

    void SetAnswer(Text _corrent, Text _an1, Text _an2, Text _an3)
    {
        int[] tempRnd = RandomTest();
        var tempAfterDeletePlus = "";

        //Delete in templist Corrent answer.

        for (int i = 0; i < tempList.Count; i++)
        {
            if (tempList[i] == _corrent.text || tempList[i] == _corrent.text)
            {
                tempAfterDeletePlus = tempList[i];
                tempList.RemoveAt(i);
            }
        }
                
        //Use tempList without corrent answer.       
        _an1.text = tempList[tempRnd[0]];
        _an2.text = tempList[tempRnd[1]];
        _an3.text = tempList[tempRnd[2]];

        //Debug.Log("BEF" + tempList.Count);

        tempList.Add(tempAfterDeletePlus);

        //Debug.Log("AFT" + tempList.Count);

        // Debug.Log( " and " + an2 + " and " + an3);
    }

    private int[] RandomTest()
    {
        int[] randomArray = new int[3]; // This array is three answers.
        System.Random rnd = new System.Random();
        for (int i = 0; i < 3; i++)
        {           
            randomArray[i] = rnd.Next(0, (int)maxQuestion - 1);   // Random 1 ~ List.Count.

            //Debug.Log("TempRnd Value" + randomArray[i]);

            for (int j = 0; j < i; j++)
            {
                while (randomArray[j] == randomArray[i])    // Check match or not.
                {
                    j = 0;  // If match j = 0 do again.
                    randomArray[i] = rnd.Next(0, (int)maxQuestion - 1);   // Random 1 ~ List.Count.
                }
            }
        }
        return randomArray;
    }

    public void CorrectAnswer(string sub)
    {
        if (sub == "A")
        {
            if (answerTextA.text == correct)
            {
                answerTextA.color = Color.green;
                clicks += 1;
            }
            else
            {
                answerTextA.color = Color.red;

                if (answerTextB.text == correct)
                {
                    answerTextB.color = Color.green;
                }
                else if (answerTextC.text == correct)
                {
                    answerTextC.color = Color.green;
                }
                else if (answerTextD.text == correct)
                {
                    answerTextD.color = Color.green;
                }

                finalCorrentList[answerListNum].status = 1;
            }
        }

        else if (sub == "B")
        {
            if (answerTextB.text == correct)
            {
                answerTextB.color = Color.green;
                clicks += 1;
            }
            else
            {
                answerTextB.color = Color.red;

                if (answerTextA.text == correct)
                {
                    answerTextA.color = Color.green;
                }
                else if (answerTextC.text == correct)
                {
                    answerTextC.color = Color.green;
                }
                else if (answerTextD.text == correct)
                {
                    answerTextD.color = Color.green;
                }

                finalCorrentList[answerListNum].status = 1;
            }
        }

        else if (sub == "C")
        {
            if (answerTextC.text == correct)
            {
                answerTextC.color = Color.green;
                clicks += 1;
            }
            else
            {
                answerTextC.color = Color.red;

                if (answerTextA.text == correct)
                {
                    answerTextA.color = Color.green;
                }
                else if (answerTextB.text == correct)
                {
                    answerTextB.color = Color.green;
                }
                else if (answerTextD.text == correct)
                {
                    answerTextD.color = Color.green;
                }

                finalCorrentList[answerListNum].status = 1;
            }
        }

        else if (sub == "D")
        {
            if (answerTextD.text == correct)
            {
                answerTextD.color = Color.green;
                clicks += 1;
            }
            else
            {
                answerTextD.color = Color.red;

                if (answerTextA.text == correct)
                {
                    answerTextA.color = Color.green;
                }
                else if (answerTextB.text == correct)
                {
                    answerTextB.color = Color.green;
                }
                else if (answerTextC.text == correct)
                {
                    answerTextC.color = Color.green;
                }

                finalCorrentList[answerListNum].status = 1;
            }
        }

        CancelInvoke("TimerDownCount");
        TempPanel.gameObject.SetActive(true);
        BackGround.GetComponent<MoveOffset>().frezz = true;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        TempPanel.gameObject.SetActive(false);
        NextQuestion();
    }

    void SaveData()
    {
        //theWords.tempList.Clear();

        TempDataList tempDataList = new TempDataList();

        for (int i = 0; i < finalCorrentList.Count; i++)
        {
            WordList endList = new WordList();
            //tempList.chinese = finalCorrentList[i].chinese;
            endList.japanese = finalCorrentList[i].japanese;
            endList.status = finalCorrentList[i].status;

            tempDataList.tempList.Add(endList);
        }

        string contents = JsonUtility.ToJson(tempDataList, true);

        StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, fileName));
        Debug.Log(file.ToString());
        file.Write(contents);
        file.Close();

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif

        Debug.Log("SAVE");

    }

    void NextQuestion()
    {
        idQuestion += 1;
        answerListNum += 1;

        if (idQuestion <= (maxQuestion - 1))
        {
            setTime = maxTime;
            InvokeRepeating("TimerDownCount", 0f, 1.0f);
            BackGround.GetComponent<MoveOffset>().frezz = false;

            SetQuestion();
            qPoint.text = (idQuestion + 1).ToString() + "/" + maxQuestion.ToString();
        }
        else
        {
            SaveData();
            average = 10 * (clicks / maxQuestion);
            finalNumber = Mathf.RoundToInt(average);
            //Debug.Log(finalNumber);

            if (finalNumber >= PlayerPrefs.GetInt("finalNumber" + levelType + iTeam.ToString()))
            {
                PlayerPrefs.SetInt("finalNumber" + levelType + iTeam.ToString(), finalNumber);
                PlayerPrefs.SetInt("average" + levelType + iTeam.ToString(), (int)average);
            }

            PlayerPrefs.SetInt("finalNumberTemp" + levelType + iTeam.ToString(), finalNumber);
            PlayerPrefs.SetInt("averageTemp" + levelType + iTeam.ToString(), (int)average);

            SceneManager.LoadScene("ImageFinalBoard");
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
