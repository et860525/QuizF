using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Expanel;


    [SerializeField]
    private GameObject ExitPop;

    private bool isExplanation = false;

    public bool isExitPanal = false;

    // Use this for initialization
    void Start ()
    {
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

    public void CallExplanation()
    {
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

    public void CallExitPop()
    {
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

    public void GoTo(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }

    public void GoExit()
    {
        Application.Quit();
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
