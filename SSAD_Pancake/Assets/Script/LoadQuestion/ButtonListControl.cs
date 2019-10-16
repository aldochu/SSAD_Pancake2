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
    private string world = "world1";
    private string chap = "chap1";
    private string difficulty = "easy"; 
    private bool listGot = false;

    private int numQuestions = 10;
    private void Start()
    {
        crudQuestion.getQuestion("world1", "chap1", "easy", callbackFunc);
    }

    private void Update()
    {
        if (listGot)
        {
            for (int i = 1; i < numQuestions + 1; i++)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(questionlist[i].question.question, i);
                button.transform.SetParent(buttonTemplate.transform.parent, false);
            }
            listGot = false;
        }
    }

    public void callbackFunc(GetQuestion[] questionList)
    {
        this.questionlist = questionList;
        //this.numQuestions = questionList.Length;
        listGot = true;
    }

    public void ButtonClicked(int questionId)
    {
        GameObject.Find("SceneController").GetComponent<ModifyChapter>().changeScene("EditQandA", world, chap, difficulty, questionlist[questionId]);
    }
}
