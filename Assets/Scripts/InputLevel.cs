using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputLevel : MonoBehaviour
{
    public GameObject[] answerInput;
    public GameObject OutPopUp;
    public GameObject WinPanel;

    public Text pointText;

    [SerializeField]
    private int maxQuestion;

    

    private int point;

    private bool isOutPopUp;

    private void Start()
    {
        point = 0;
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

    private void FixedUpdate()
    {
        CheckEnd();
    }

    public void CheckEnd()
    {
        if (point == maxQuestion)
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);
            //SceneManager.LoadScene("FinalBoard");
        }
    }

    public void GetSet(int i)
    {
        switch(i)
        {
            case 0:
                if (answerInput[i].GetComponent<InputField>().text == "head" || answerInput[i].GetComponent<InputField>().text == "Head")
                {
                    point++;
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.black;
                    answerInput[i].GetComponent<InputField>().interactable = false;
                    //answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.red;
                    Debug.Log("No");
                }
                break;
            case 1:
                if (answerInput[i].GetComponent<InputField>().text == "neck" || answerInput[i].GetComponent<InputField>().text == "Neck")
                {
                    point++;
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.black;
                    answerInput[i].GetComponent<InputField>().interactable = false;
                    //answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.red;
                    Debug.Log("No");
                }
                break;
            case 2:
                if (answerInput[i].GetComponent<InputField>().text == "arm" || answerInput[i].GetComponent<InputField>().text == "Arm")
                {
                    point++;
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.black;
                    answerInput[i].GetComponent<InputField>().interactable = false;
                    //answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.red;
                    Debug.Log("No");
                }
                break;
            case 3:
                if (answerInput[i].GetComponent<InputField>().text == "body" || answerInput[i].GetComponent<InputField>().text == "Body")
                {
                    point++;
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.black;
                    answerInput[i].GetComponent<InputField>().interactable = false;
                    //answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.red;
                    Debug.Log("No");
                }
                break;
            case 4:
                if (answerInput[i].GetComponent<InputField>().text == "leg" || answerInput[i].GetComponent<InputField>().text == "Leg")
                {
                    point++;
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.black;
                    answerInput[i].GetComponent<InputField>().interactable = false;
                    //answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    answerInput[i].transform.Find("Text").GetComponent<Text>().color = Color.red;
                    Debug.Log("No");
                }
                break;
        }

        pointText.text = point.ToString() + "/" + maxQuestion.ToString(); 
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
        SceneManager.LoadScene("FoodSelectMenu");
    }
}
