using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputLevel : MonoBehaviour
{
    public GameObject[] answerInput;
    public Text pointText;

    [SerializeField]
    private int maxQuestion;

    private int point; 

    private void Start()
    {
        point = 0;
    }

    private void FixedUpdate()
    {
        CheckEnd();
    }

    public void CheckEnd()
    {
        if (point == maxQuestion)
        {
            SceneManager.LoadScene("FinalBoard");
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
                    answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    Debug.Log("No");
                }
                break;
            case 1:
                if (answerInput[i].GetComponent<InputField>().text == "neck" || answerInput[i].GetComponent<InputField>().text == "Neck")
                {
                    point++;
                    answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    Debug.Log("No");
                }
                break;
            case 2:
                if (answerInput[i].GetComponent<InputField>().text == "arm" || answerInput[i].GetComponent<InputField>().text == "Arm")
                {
                    point++;
                    answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    Debug.Log("No");
                }
                break;
            case 3:
                if (answerInput[i].GetComponent<InputField>().text == "body" || answerInput[i].GetComponent<InputField>().text == "Body")
                {
                    point++;
                    answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    Debug.Log("No");
                }
                break;
            case 4:
                if (answerInput[i].GetComponent<InputField>().text == "leg" || answerInput[i].GetComponent<InputField>().text == "Leg")
                {
                    point++;
                    answerInput[i].SetActive(false);
                    Debug.Log("Yes");
                }
                else
                {
                    Debug.Log("No");
                }
                break;
        }

        pointText.text = point.ToString() + "/" + maxQuestion.ToString(); 
    }
}
