using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    private int numQuestions = 20;
    private void Start()
    {
        for (int i = 1; i < numQuestions + 1; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().SetText("Question " + i);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
}
