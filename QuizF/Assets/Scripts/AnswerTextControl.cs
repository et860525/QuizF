using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTextControl : MonoBehaviour {

    [SerializeField]
    private GameObject textTemplate;

    private List<GameObject> textItems;

    private void Start()
    {
        textItems = new List<GameObject>();
    }

    public void LogText(int maxItem, string newTextString, Color newColor)
    {
        if (textItems.Count == maxItem)
        {
            GameObject tempItem = textItems[0];
            Destroy(tempItem.gameObject);
            textItems.Remove(tempItem);
        }

        GameObject newText = Instantiate(textTemplate) as GameObject;
        newText.SetActive(true);

        newText.GetComponent<AnswerText>().SetText(newTextString, newColor);
        newText.transform.SetParent(textTemplate.transform.parent, false);

        textItems.Add(newText.gameObject);
    }
}
