using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputLevel : MonoBehaviour
{
    public List<GameObject> answerInput;
    public GameObject OutPopUp;
    public GameObject WinPanel;

    private string levelType;
    private string levelName;

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

    public void GetAnswerInt(int i)
    {
        if (answerInput[i].GetComponent<InputField>().text == answerInput[i].name)
        {
            answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.green;
            answerInput[i].GetComponent<InputField>().interactable = false;
            checkAll++;
            crrect++;
            //Debug.Log("Yes");
        }
        else if (answerInput[i].GetComponent<InputField>().text != answerInput[i].name && answerInput[i].GetComponent<InputField>().text != "") 
        {
            answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.red;
            answerInput[i].GetComponent<InputField>().interactable = false;
            checkAll++;
            //Debug.Log("No");
        }

        if (checkAll == answerInput.Count)
        {
            WinPanel.SetActive(true);
            WinPanel.transform.Find("Image").transform.Find("Text").GetComponent<Text>().text = crrect.ToString() + " / " + thePoint.ToString();

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
        if (levelType == "Animal")
        {
            SceneManager.LoadScene("AnimalSelectMenu");
        }
    }
}
