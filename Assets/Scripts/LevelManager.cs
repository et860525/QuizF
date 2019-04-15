using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{    
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

    private AudioSource timeSound;

    //Class
    private StringData theWords = new StringData(); //Load Json dataBase.
    private List<WordList> questionWords; //Store words.    
    private List<WordList> finalCorrentList; //Store corrent answer and save.

    //Static
    private static float maxTime = 11; // Set 11 beacuse Invok will delay.
    private static string gameModeString; // Set mode is jp -> ch or ch -> jp.

    //Intger
    private int iTeam; //Set Level.
    private int idQuestion; // Set question number.
    private int finalNumber; // Set final point.
    private int answerListNum; // If answer is wrong and change Words status.

    //Float
    private float setTime; // Set time.
    private float clicks; // Right answer and caculate point.
    private float average; // Calculate point.
    private float maxQuestion; 
    
    //String
    private string levelType;
    private string correct;
    private string fileName = "FinalList.json";

    //Bool
    private bool isOutPopUp; // Controll the panel.


    /*
     * Two part: 1.Check LevelType 2.Check question is Ch or Jp 
    */
    private void Start()
    {
        //Screen.fullScreen = false;
        Time.timeScale = 1;

        BackGround = GameObject.FindGameObjectWithTag("BackGround");

        //Get Level Information
        iTeam = PlayerPrefs.GetInt("iTeam");
        levelType = PlayerPrefs.GetString("LevelType");
        
        questionWords = new List<WordList>();
        finalCorrentList = new List<WordList>();

        timeSound = GetComponent<AudioSource>();
        
        answerListNum = 0;
        setTime = maxTime;
     
        idQuestion = 0;

        InvokeRepeating("TimerDownCount", 0f, 1f);

        LoadData(levelType);

        SetQuestion(levelType);

        qPoint.text = (idQuestion + 1).ToString() + "/" + maxQuestion.ToString();
    }

    void TimerDownCount()
    {
        setTime -= 1;
        timeSound.Play();
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

    void LoadData(string _leveltype)
    {
        TextAsset file = Resources.Load("DataBase/" + _leveltype + "DataBase") as TextAsset;

        // OLD MOTHERFUCKER SCHOOL
        /*try
        {
            if (_leveltype == "Animal")
            {
                file = Resources.Load("Animal/AnimalDataBase") as TextAsset;
            }
            if (_leveltype == "Cuisime")
            {
                file = Resources.Load("Cuisime/CuisimeDataBase") as TextAsset;
            }
            if (_leveltype == "Fruit")
            {
                file = Resources.Load("Fruit/FruitDataBase") as TextAsset;
            }
            if (_leveltype == "Meat")
            {
                file = Resources.Load("Meat/MeatDataBase") as TextAsset;
            }
            if (_leveltype == "Vegetable")
            {
                file = Resources.Load("Vegetable/VegetableDataBase") as TextAsset;
            }
        }
        catch(System.Exception ex)
        {
            Debug.Log(ex.Message);
        }*/
        //string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        //string filePath = Path.Combine(Application.dataPath, fileName);        
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

                switch (_leveltype)
                {
                    case "Animal":
                        if (iTeam == 3)
                        {
                            for (int i = 0; i < theWords.Animal1.Count; i++)
                            {
                                getJsonList.Add(theWords.Animal1[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        if (iTeam == 6)
                        {
                            for (int i = 0; i < theWords.Animal2.Count; i++)
                            {
                                getJsonList.Add(theWords.Animal2[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        if (iTeam == 9)
                        {
                            for (int i = 0; i < theWords.Animal3.Count; i++)
                            {
                                getJsonList.Add(theWords.Animal3[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        break;
                    case "Cuisime":
                        if (iTeam == 3)
                        {
                            for (int i = 0; i < theWords.Cuisime1.Count; i++)
                            {
                                getJsonList.Add(theWords.Cuisime1[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        if (iTeam == 6)
                        {
                            for (int i = 0; i < theWords.Cuisime2.Count; i++)
                            {
                                getJsonList.Add(theWords.Cuisime2[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        break;
                    case "Fruit":
                        if (iTeam == 3)
                        {
                            for (int i = 0; i < theWords.Fruit1.Count; i++)
                            {
                                getJsonList.Add(theWords.Fruit1[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        if (iTeam == 6)
                        {
                            for (int i = 0; i < theWords.Fruit2.Count; i++)
                            {
                                getJsonList.Add(theWords.Fruit2[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        break;
                    case "Meat":
                        if (iTeam == 3)
                        {
                            for (int i = 0; i < theWords.Meat1.Count; i++)
                            {
                                getJsonList.Add(theWords.Meat1[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        break;
                    case "Vegetable":
                        if (iTeam == 3)
                        {
                            for (int i = 0; i < theWords.Vegetable1.Count; i++)
                            {
                                getJsonList.Add(theWords.Vegetable1[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        if (iTeam == 6)
                        {
                            for (int i = 0; i < theWords.Vegetable2.Count; i++)
                            {
                                getJsonList.Add(theWords.Vegetable2[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        break;
                    case "MakeUp":
                        if (iTeam == 3)
                        {
                            for (int i = 0; i < theWords.MakeUp1.Count; i++)
                            {
                                getJsonList.Add(theWords.MakeUp1[i]);
                                //Debug.Log(getJsonList.Count);
                            }
                        }
                        break;
                        //.....ADD TYPE.
                }

                for (int i = 0; i < getJsonList.Count; i++)
                {
                    questionWords.Add(getJsonList[i]);
                }

                maxQuestion = questionWords.Count;

               for (int i = 0; i < questionWords.Count; i++)
                {
                    Debug.Log(questionWords.Count);
                    Debug.Log(questionWords[i].japanese);
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

    //Set Question Jp or Ch.
    void SetQuestion(string _levelType)
    {
        answerTextA.color = Color.black;
        answerTextB.color = Color.black;
        answerTextC.color = Color.black;
        answerTextD.color = Color.black;

        answerTextA.fontSize = 70;
        answerTextB.fontSize = 70;
        answerTextC.fontSize = 70;
        answerTextD.fontSize = 70;

        string _gameMode = "";

        int randomForGameMode = Random.Range(0, 2);
        int randomQuestionIndex = Random.Range(0, questionWords.Count); // Depend questionWords list Count (questionWords is --), and random in the questionWords question.
        int randomCorrent = Random.Range(1, 4);

        //Check question is ch or jp.

        if (randomForGameMode == 0)
        {
            _gameMode = "jp";
            qText.text = questionWords[randomQuestionIndex].japanese;
            if (qText.text.Length > 6)
            {
                qText.fontSize = 50;
            }
            correct = questionWords[randomQuestionIndex].chinese;
            finalCorrentList.Add(questionWords[randomQuestionIndex]);
            questionWords.RemoveAt(randomQuestionIndex);
        }
        else if (randomForGameMode == 1)
        {
            _gameMode = "ch";
            qText.text = questionWords[randomQuestionIndex].chinese;
            correct = questionWords[randomQuestionIndex].japanese;
            finalCorrentList.Add(questionWords[randomQuestionIndex]);
            questionWords.RemoveAt(randomQuestionIndex);
        }


        //Set Answer.
        switch (randomCorrent)  // Set correct answer.
        {
            case 1:
                answerTextA.text = correct;
                if (answerTextA.text.Length > 6)
                {
                    answerTextA.fontSize = 50;
                }
                SetAnswer(_levelType, _gameMode, answerTextA, answerTextB, answerTextC, answerTextD);
                break;
            case 2:
                answerTextB.text = correct;
                if (answerTextA.text.Length > 6)
                {
                    answerTextA.fontSize = 50;
                }
                SetAnswer(_levelType, _gameMode, answerTextB, answerTextA, answerTextC, answerTextD);
                break;
            case 3:
                answerTextC.text = correct;
                if (answerTextA.text.Length > 6)
                {
                    answerTextA.fontSize = 50;
                }
                SetAnswer(_levelType, _gameMode, answerTextC, answerTextA, answerTextB, answerTextD);
                break;
            case 4:
                answerTextD.text = correct;
                if (answerTextA.text.Length > 6)
                {
                    answerTextA.fontSize = 50;
                }
                SetAnswer(_levelType, _gameMode, answerTextD, answerTextA, answerTextB, answerTextC);
                break;
        }
    }

    void SetAnswer(string __levelType, string __gameMode, Text _corrent, Text _an1, Text _an2, Text _an3)
    {
        var tempList = new List<WordList>();
        int[] tempRnd = RandomTest();

        //Delete in templist Corrent answer.
        switch (__levelType)
        {
            case "Animal":
                if (iTeam == 3)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Animal1[i]);
                    }
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                else if (iTeam == 6)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Animal2[i]);
                    }
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                else if (iTeam == 9)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Animal3[i]);
                    }
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                break;
            case "Cuisime":
                if (iTeam == 3)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Cuisime1[i]);
                    }

                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                else if (iTeam == 6)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Cuisime2[i]);
                    }
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                break;
            case "Fruit":
                if (iTeam == 3)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Fruit1[i]);
                    }

                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                else if (iTeam == 6)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Fruit2[i]);
                    }
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                break;
            case "Meat":
                if (iTeam == 3)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Meat1[i]);
                    }

                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                break;
            case "Vegetable":
                if (iTeam == 3)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Vegetable1[i]);
                    }

                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                else if (iTeam == 6)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.Vegetable2[i]);
                    }
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                break;
            case "MakeUp":
                if (iTeam == 3)
                {
                    for (int i = 0; i <= (int)maxQuestion - 1; i++)
                    {
                        tempList.Add(theWords.MakeUp1[i]);
                    }

                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].chinese == _corrent.text || tempList[i].japanese == _corrent.text)
                        {
                            tempList.RemoveAt(i);
                        }
                    }
                }
                break;
                //Add type
        }

        //Use tempList without corrent answer.
        switch (__gameMode)
        {
            case "jp":
                _an1.text = tempList[tempRnd[0]].chinese;
                _an2.text = tempList[tempRnd[1]].chinese;
                _an3.text = tempList[tempRnd[2]].chinese;
                break;

            case "ch":
                _an1.text = tempList[tempRnd[0]].japanese;
                _an2.text = tempList[tempRnd[1]].japanese;
                _an3.text = tempList[tempRnd[2]].japanese;

                if (_an1.text.Length > 6)
                {
                    _an1.fontSize = 50;
                }
                if (_an2.text.Length > 6)
                {
                    _an2.fontSize = 50;
                }
                if (_an3.text.Length > 6)
                {
                    _an3.fontSize = 50;
                }

                break;
        }
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
        Debug.Log(file.ToString());
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
            SetQuestion(levelType);
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

            SceneManager.LoadScene("WordFinalBoard");
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
        SceneManager.LoadScene(levelType + "SelectMenu");
        /*switch(levelType)
        {
            case "Animal":
                SceneManager.LoadScene("AnimalSelectMenu");
                break;
            case "Cuisime":
                SceneManager.LoadScene("CuisimeSelectMenu");
                break;
            case "Fruit":
                SceneManager.LoadScene("FruitSelectMenu");
                break;
            case "Meat":
                SceneManager.LoadScene("MeatSelectMenu");
                break;
            case "Vegetable":
                SceneManager.LoadScene("VegetableSelectMenu");
                break;
        }*/

    }
}
