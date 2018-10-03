using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    [SerializeField]
    private string setLevelType;

    public Button goButton;

    public Text txtSelectName;
    public Text txtPointInfo;
    public Text TextTest;

    public GameObject selectInfo; 
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private AudioSource buttonClik;

    public string[] levelName;
    public int numberConst;

    private string levelType;
    private int iTeam;

    private void Start()
    {
        levelType = PlayerPrefs.GetString("LevelType");

        buttonClik = GetComponent<AudioSource>();

        if (levelType == null)
        {
            switch(SceneManager.GetActiveScene().ToString())
            {
                case "FoodSelectMenu":
                    levelType = setLevelType;
                    break;
                case "FurnitureSelectMenu":
                    levelType = setLevelType;
                    break;
                case "AnimalSelectMenu":
                    levelType = setLevelType;
                    break;
            }
        }

        TextTest.text = levelType;
        
        Time.timeScale = 1;
        iTeam = 0;
        txtSelectName.text = levelName[iTeam];
        txtPointInfo.text = "You got 0 of 10";
        selectInfo.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        goButton.interactable = false;
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
                GoTo("MainMenu");
            }
        }
        //PC Test.
        /*if (Input.GetKeyDown(KeyCode.O))
        {
            // Quit the application
            GoTo("MainMenu");
        }*/
    }

    //Set Level
    public void SelectLevel(int i)
    {
        buttonClik.Play();
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        iTeam = i;
        PlayerPrefs.SetInt("iTeam", iTeam);
        //LevelName
        PlayerPrefs.SetString("LevelName", levelType + iTeam.ToString());

        txtSelectName.text = levelName[iTeam];
        int finalNumber = PlayerPrefs.GetInt("finalNumber" + levelType + iTeam.ToString());
        int average = PlayerPrefs.GetInt("average" + levelType + iTeam.ToString());        

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
        
        txtPointInfo.text = "You got " + average.ToString() + " of " + numberConst.ToString();       
        selectInfo.SetActive(true);
        goButton.interactable = true;
    }

    public void SetGameMode(string gameMode)
    {
        PlayerPrefs.SetString("gameMode", gameMode);
    }

    public void SetStartQuestionNuber(int start_number)
    {
        PlayerPrefs.SetInt("StartQuestionNuber", start_number);
    }

    public void SetLastQuestionNuber(int last_number)
    {
        PlayerPrefs.SetInt("LastQuestionNuber", last_number);
    }

    public void SetMaxQuestionNumber(int max_number)
    {
        PlayerPrefs.SetInt("MaxQuestionNumber", max_number);
    }
    
    
    //GoTo
    public void GoToLevel()
    {
        buttonClik.Play();
        PlayerPrefs.SetString("LevelUsed" + levelType + iTeam.ToString(), "Open");

        switch (levelType)
        {
            case "Food":
                if (iTeam == 1 || iTeam == 2)
                {
                    SceneManager.LoadScene("WordLevel");
                }
                else if (iTeam == 3)
                {
                    SceneManager.LoadScene("Level3");
                }
                break;
            case "Furniture":
                if (iTeam == 1 || iTeam == 2)
                {
                    SceneManager.LoadScene("WordLevel");
                }
                else if (iTeam == 3)
                {
                    SceneManager.LoadScene("Level3");
                }
                break;
            case "Animal":
                if (iTeam == 1)
                {
                    PlayerPrefs.SetString("ExplorerName", "Animal1");
                    SceneManager.LoadScene("ImageLevel");
                }
                else if (iTeam == 2)
                {
                    PlayerPrefs.SetString("ExplorerName", "Animal2");
                    SceneManager.LoadScene("ImageLevel");
                }
                else if (iTeam == 3)
                {
                    PlayerPrefs.SetString("ExplorerName", "Animal3");
                    SceneManager.LoadScene("ImageLevel");
                }
                break;
        }


    }

    public void GoTo(string nameScene)
    {
        buttonClik.Play();
        SceneManager.LoadScene(nameScene);
    }

}
