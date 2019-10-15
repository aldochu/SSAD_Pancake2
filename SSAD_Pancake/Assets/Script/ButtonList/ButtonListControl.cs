using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    public CRUDquestion crudQuestion;

    private int numQuestions = 20;
    private void Start()
    {
        crudQuestion = GetComponent<CRUDquestion>();
        crudQuestion.getQuestion("world1", "chap1", "easy", callbackFunc);
    }

    public void callbackFunc(GetQuestion[] questionList)
    {
        
        Debug.Log("CAll back begin");
        /*
        for (int i = 0; i < 50; i++)
        {
            Debug.Log("Key: " + questionList[i].UniqueKey);
            Debug.Log("Question: " + questionList[i].question.question);
        }
        */

        for (int i = 1; i < numQuestions + 1; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().SetText("Question " + questionList[i].question.question);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
}
