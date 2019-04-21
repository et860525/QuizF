using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Expanel;

    [SerializeField]
    private GameObject ExitPop;

    [SerializeField]
    private GameObject DeletePop;

    private AudioSource buttonClik;

    private bool isExplanation = false;

    private bool isExitPanal = false;

    private bool isDeletePanal = false;

    private string fileName = "OnlyString.json";

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
        /*if (Input.GetKeyDown(KeyCode.O))
        {
            // Quit the application
            CallExitPop();
        }*/
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

    //Delete Panel
    public void CallDeletePop()
    {
        buttonClik.Play();
        isDeletePanal = !isDeletePanal;

        if (isDeletePanal)
        {
            DeletePop.gameObject.SetActive(true);
        }

        if (!isDeletePanal)
        {
            DeletePop.gameObject.SetActive(false);
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
        ClearJson();
        PlayerPrefs.DeleteAll();
        DeletePop.gameObject.SetActive(false);
    }

    void ClearJson()
    {
        string filePath = Application.persistentDataPath + "/" + fileName;

        if (File.Exists(filePath))
        {
            StreamReader path = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, fileName));
            //Debug.Log(Application.persistentDataPath);
            //Debug.Log(path);
            string loadJson = path.ReadToEnd();
            Debug.Log(loadJson);
            path.Close();

            OnlyStringData loadData = JsonUtility.FromJson<OnlyStringData>(loadJson);

            loadData.Animal1_Temp.Clear();
            loadData.Animal2_Temp.Clear();
            loadData.Animal3_Temp.Clear();
            loadData.Cuisime1_Temp.Clear();
            loadData.Cuisime2_Temp.Clear();
            loadData.Fruit1_Temp.Clear();
            loadData.Fruit2_Temp.Clear();
            loadData.MakeUp1_Temp.Clear();
            loadData.Meat1_Temp.Clear();
            loadData.Vegetable1_Temp.Clear();
            loadData.Vegetable2_Temp.Clear();

            loadData.MakeUp1_Temp.Clear();
            loadData.Position1_Temp.Clear();
            loadData.Position2_Temp.Clear();
            loadData.Position3_Temp.Clear();
            loadData.EleProducts1_Temp.Clear();
            loadData.Clothes1_Temp.Clear();
            loadData.Contry1_Temp.Clear();
            loadData.Contry2_Temp.Clear();
            loadData.Family1_Temp.Clear();
            loadData.Transport1_Temp.Clear();
            loadData.Festival1_Temp.Clear();
            loadData.Subject1_Temp.Clear();
            loadData.Hair1_Temp.Clear();
            loadData.Fitting1_Temp.Clear();
            loadData.Body1_Temp.Clear();
            loadData.Body2_Temp.Clear();
            loadData.Weather1_Temp.Clear();
            loadData.Dessert1_Temp.Clear();
            loadData.Dessert2_Temp.Clear();
            loadData.Dessert3_Temp.Clear();
            loadData.Stationery1_Temp.Clear();
            loadData.Shoes1_Temp.Clear();
            loadData.Colors1_Temp.Clear();
            loadData.Beverage1_Temp.Clear();
            loadData.Facility1_Temp.Clear();
            loadData.Sport1_Temp.Clear();
            loadData.Sport2_Temp.Clear();
            loadData.Disaster1_Temp.Clear();
            loadData.Plant1_Temp.Clear();
            loadData.Career1_Temp.Clear();
            loadData.Career2_Temp.Clear();
            loadData.Furniture1_Temp.Clear();
            loadData.Furniture2_Temp.Clear();


            string contents = JsonUtility.ToJson(loadData, true);

            StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, fileName));
            Debug.Log(file.ToString());
            file.Write(contents);
            file.Close();


#if UNITY_EDITOR && UNITY_ANDROID
            UnityEditor.AssetDatabase.Refresh();
#endif

            Debug.Log("SAVE");
        }
    }
}
