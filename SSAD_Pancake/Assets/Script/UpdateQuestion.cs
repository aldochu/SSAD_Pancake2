using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateQuestion : MonoBehaviour
{

    public System.String question, ans1, ans2, ans3, ans4, correctAns, difficulty;
    public InputField q, diff, a1, a2, a3, a4, correctA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateQuestion()
    {
        q = GameObject.Find("InputQuestion").GetComponent<InputField>();
        diff = GameObject.Find("Difficulty").GetComponent<InputField>();
        a1 = GameObject.Find("InputAnswer1").GetComponent<InputField>();
        a2 = GameObject.Find("InputAnswer2").GetComponent<InputField>();
        a3 = GameObject.Find("InputAnswer3").GetComponent<InputField>();
        a4 = GameObject.Find("InputAnswer4").GetComponent<InputField>();
        correctA = GameObject.Find("CorrectAnswer").GetComponent<InputField>();

        question = q.text;
        difficulty = diff.text;
        ans1 = a1.text;
        ans2 = a2.text;
        ans3 = a3.text;
        ans4 = a4.text;
        correctAns = correctA.text;
    }
}
