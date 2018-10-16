using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    public int iTeam;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public GameObject InteractableButton;

    private string levelType;

    //private int finalNumber;

    // Use this for initialization
    void Start ()
    {
        levelType = PlayerPrefs.GetString("LevelType");

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false); 
               
        int finalNumber = PlayerPrefs.GetInt("finalNumber" + levelType + iTeam.ToString());

        if (finalNumber >= 10)
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

        SetInteractable(finalNumber);
    }

    public void SetInteractable(int finalNumber)
    {
        if (finalNumber >= 10)
        {
            InteractableButton.GetComponent<Button>().interactable = true;
        }
    }
}
