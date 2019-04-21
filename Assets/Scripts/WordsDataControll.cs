using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsDataControll : MonoBehaviour
{
    [SerializeField]
    private GameObject wordsTemplate;

    private List<GameObject> wdList;

    void Start()
    {
        wdList = new List<GameObject>();
    }

    public void GetWordString(int maxNum, string type, string jp, string ch, Color myColor)
    {

        if (wdList.Count >= maxNum)
        {
            GameObject tempItem = wdList[0];
            Destroy(tempItem.gameObject);
            wdList.Remove(tempItem);
        }

        if (GameObject.Find("Words(Clone)") != null && GameObject.Find("Words(Clone)").GetComponent<WordsDataShow>().type != type)
        {
            GameObject tempItem = wdList[0];
            Destroy(tempItem.gameObject);
            wdList.Remove(tempItem);
        }

        GameObject tWord = Instantiate(wordsTemplate) as GameObject;
        tWord.SetActive(true);

        tWord.GetComponent<WordsDataShow>().SetText(jp, ch, type, myColor);

        tWord.transform.SetParent(wordsTemplate.transform.parent, false);

        wdList.Add(tWord.gameObject);
    }

    public void GetWordString(int maxNum, string type, string jp, string ch, Sprite sp, Color myColor)
    {

        if (wdList.Count >= maxNum)
        {
            GameObject tempItem = wdList[0];
            Destroy(tempItem.gameObject);
            wdList.Remove(tempItem);
        }

        if (GameObject.Find("Words(Clone)") != null && GameObject.Find("Words(Clone)").GetComponent<WordsDataShow>().type != type)
        {
            GameObject tempItem = wdList[0];
            Destroy(tempItem.gameObject);
            wdList.Remove(tempItem);
        }

        GameObject tWord = Instantiate(wordsTemplate) as GameObject;
        tWord.SetActive(true);

        tWord.GetComponent<WordsDataShow>().SetText(jp, ch, type, sp, myColor);

        tWord.transform.SetParent(wordsTemplate.transform.parent, false);

        wdList.Add(tWord.gameObject);
    }

    public void DataBaseGetWords(List<WordList> final, string type, int maxNum, Color myColor)
    {
        var tempCount = wdList.Count;
        if (GameObject.Find("Words(Clone)"))
        {
            if (GameObject.Find("Words(Clone)").tag != type)
            {
                for (int i = 0; i <= PlayerPrefs.GetInt("tempCount") - 1; i++)
                {
                    GameObject tempItem = wdList[0];
                    Destroy(tempItem.gameObject);
                    wdList.Remove(tempItem);
                }
            }
        }

        if (maxNum != 0)
        {
            for (int i = 0; i <= maxNum; i++)
            {
                GameObject tWord = Instantiate(wordsTemplate) as GameObject;
                tWord.SetActive(true);
                tWord.GetComponent<WordsDataShow>().SetText(final[i].japanese, final[i].chinese, type, myColor);
                tWord.transform.SetParent(wordsTemplate.transform.parent, false);
                //tWord.tag = type;
                wdList.Add(tWord.gameObject);
                Debug.Log(wdList[i].GetComponent<WordsDataShow>().type);
            }
            PlayerPrefs.SetInt("tempCount", wdList.Count);
        }
    }
}


 