using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Expanel;

    [SerializeField]
    private GameObject ExitPop;

    private AudioSource buttonClik;

    private bool isExplanation = false;

    private bool isExitPanal = false;

    // Use this for initialization
    void Start ()
    {
        buttonClik = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isExitPanal == true)
                {
                    // Quit the application
                    GoExit();
                }
                else
                {
                    CallExitPop();
                }
            }
        }

        //PC Test.
        if (Input.GetKeyDown(KeyCode.O))
        {
            // Quit the application
            CallExitPop();
        }
    }

    //-----Controll Button-----

    public void GoTo(string nameScene)
    {
        buttonClik.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }

    //Explanation Panel
    public void CallExplanation()
    {
        buttonClik.Play();
        isExplanation = !isExplanation;

        if (isExplanation)
        {
            Expanel.gameObject.SetActive(true);
        }

        if (!isExplanation)
        {
            Expanel.gameObject.SetActive(false);
        }
    }

    //Exit Panel
    public void CallExitPop()
    {
        buttonClik.Play();
        isExitPanal = !isExitPanal;

        if (isExitPanal)
        {
            ExitPop.gameObject.SetActive(true);
        }

        if (!isExitPanal)
        {
            ExitPop.gameObject.SetActive(false);
        }
    }

    

    public void GoExit()
    {
        buttonClik.Play();
        Application.Quit();
    }

    public void DeleteAll()
    {
        buttonClik.Play();
        PlayerPrefs.DeleteAll();
    }
}
