using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    public CRUDquestion crudQuestion;

    private GetQuestion[] questionlist;
    private bool listGot = false;

    private int numQuestions = 10;
    private void Start()
    {
        //crudQuestion = GetComponent<CRUDquestion>();
        crudQuestion.getQuestion("world1", "chap1", "easy", callbackFunc);
        //Debug.Log(crudQuestion.questionList[0].question.question);

    }

    private void Update()
    {
        if (listGot)
        {
            for (int i = 1; i < numQuestions + 1; i++)
            {
                Debug.Log(": " + questionlist[i].question.question);
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText("Question " + questionlist[i].question.question);
                Debug.Log("Question: " + questionlist[i].question.question);
                button.transform.SetParent(buttonTemplate.transform.parent, false);
            }
            listGot = false;
        }
    }

    public void callbackFunc(GetQuestion[] questionList)
    {
        
        Debug.Log("CAll back begin");
        //Debug.Log(questionList[0].question.question);
        /*
        for (int i = 0; i < 50; i++)
        {
            Debug.Log("Key: " + questionList[i].UniqueKey);
            Debug.Log("Question: " + questionList[i].question.question);
        }
        */
        this.questionlist = questionList;
        listGot = true;

    }
}
