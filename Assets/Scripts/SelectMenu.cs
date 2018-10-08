using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
 
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
                GoTo("TypeSelectMenu");
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
    
    //GoTo
    public void GoToLevel()
    {
        buttonClik.Play();
        
        switch (levelType)
        {
            case "Furniture":
                if (iTeam == 1)
                {
                    //Open data base (1).
                    PlayerPrefs.SetString("LevelUsed" + levelType + iTeam.ToString(), "Open");
                    SceneManager.LoadScene("WordLevel");
                }
                else if (iTeam == 2)
                {
                    SceneManager.LoadScene("WordLevel");
                }
                else if (iTeam == 3)
                {
                    SceneManager.LoadScene("WordLevel");
                }
                break;

            case "Animal":
                if (iTeam == 1)
                {
                    //Open data base (1).
                    PlayerPrefs.SetString("LevelUsed" + levelType + iTeam.ToString(), "Open");
                    PlayerPrefs.SetString("LevelID", "Animal1");
                    SceneManager.LoadScene("AnimalOneInput");
                }
                else if (iTeam == 2)
                {
                    PlayerPrefs.SetString("ExplorerName", "Animal1");
                    SceneManager.LoadScene("ImageLevel");
                }
                else if (iTeam == 3)
                {
                    SceneManager.LoadScene("WordLevel");
                }
                else if (iTeam == 4)
                {
                    //Open data base (4).
                    PlayerPrefs.SetString("LevelUsed" + levelType + iTeam.ToString(), "Open");
                    PlayerPrefs.SetString("LevelID", "Animal2");
                    SceneManager.LoadScene("AnimalTwoInput");
                }
                else if (iTeam == 5)
                {
                    PlayerPrefs.SetString("ExplorerName", "Animal2");
                    SceneManager.LoadScene("ImageLevel");
                }
                else if (iTeam == 6)
                {
                    SceneManager.LoadScene("WordLevel");
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
