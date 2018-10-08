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

    private int checkAll;

    private bool isOutPopUp;

    private void Start()
    {
        //Screen.fullScreen = false;
        checkAll = 0;
        levelType = PlayerPrefs.GetString("LevelType");
        levelName = PlayerPrefs.GetString("LevelID");
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
