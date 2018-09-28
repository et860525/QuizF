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
