using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypeSelectMenu : MonoBehaviour
{
    private AudioSource buttonClik;

    private void Start()
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

                // Quit the application
                GoTo("MainMenu");
            }
        }
    }

    public void SetType(string type)
    {
        buttonClik.Play();
        PlayerPrefs.SetString("LevelType", type);
    }

    public void GoTo(string nameScene)
    {
        buttonClik.Play();
        SceneManager.LoadScene(nameScene);
    }
}
