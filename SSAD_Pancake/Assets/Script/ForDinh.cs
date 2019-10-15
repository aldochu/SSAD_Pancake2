using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDinh : MonoBehaviour
{
    public CRUDquestion crudQuestion;
    // Start is called before the first frame update
    void Start()
    {
        crudQuestion = GetComponent<CRUDquestion>();

        crudQuestion.getQuestion("world1", "chap1", "easy", callbackFunc);
    }

    public void callbackFunc(GetQuestion[] questionList)
    {
        Debug.Log("CAll back begin");
        for (int i = 0; i < 50; i++)
        {
            Debug.Log("Key: " + questionList[i].UniqueKey);
            Debug.Log("Question: " + questionList[i].question.question);
        }
    }
}
