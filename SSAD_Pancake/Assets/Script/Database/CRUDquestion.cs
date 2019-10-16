using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;


public class CRUDquestion : MonoBehaviour
{
    private DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    // Start is called before the first frame update

    void Start()
    {
        // Set this before calling into the realtime database.
        /*FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");*/

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssad-c9270.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;


        RandomlyGenerateQuestion();
        // GetQuestion[] qns;
        // getQuestion("world1", "chap1", "easy");
        /*getQuestion("world1", "chap1", "easy", (result) =>
        {
            qns = result;
        });*/

        //sample of how to update question difficulty
        /*
        GetQuestion test = new GetQuestion();
        test.question.question = "22+20=?";
        test.question.ans1 = "39";
        test.question.ans2 = "40";
        test.question.ans3 = "41";
        test.question.ans4 = "42";
        test.question.correctAns = "42";
        test.UniqueKey = "1114554";
        UpdateQuestionDifficulty("world1", "chap1", "easy","normal",test);
        */

    }



    public void RandomlyGenerateQuestion()
    {
        UploadQuestion newQuestion = new UploadQuestion();

        for (int k = 0; k < 20; k++)
        {
            int exp = 60;

            newQuestion.question = "" + exp + "+" + (exp + k) + "=?";
            newQuestion.ans1 = (exp * 2 + k - 2).ToString();
            newQuestion.ans2 = (exp * 2 + k - 1).ToString();
            newQuestion.ans3 = (exp * 2 + k).ToString();
            newQuestion.ans4 = (exp * 2 + k + 1).ToString();
            newQuestion.correctAns = (exp * 2 + k).ToString();
            AddNewQuestion("world1", "chap3", "easy", newQuestion);
            AddNewQuestion("world1", "chap3", "normal", newQuestion);
            AddNewQuestion("world1", "chap3", "hard", newQuestion);

        }
    }


    public void AddNewQuestion(string world, string chap, string difficulty, UploadQuestion question)
    {

        string UniqueKey = Random.Range(0, 10000).ToString() + System.DateTime.Now.Minute.ToString()+System.DateTime.Now.Second.ToString();

        string json = JsonUtility.ToJson(question);


        mDatabaseRef.Child("question").Child(world).Child(chap).Child(difficulty).Child(UniqueKey).SetRawJsonValueAsync(json);
    }

    public void UpdateQuestion(string world, string chap, string difficulty, GetQuestion question)
    {
        string json = JsonUtility.ToJson(question.question);

        mDatabaseRef.Child("question").Child(world).Child(chap).Child(difficulty).Child(question.UniqueKey).SetRawJsonValueAsync(json);

    }

    public void UpdateQuestionDifficulty(string world, string chap, string oldDifficulty,string newDifficulty, GetQuestion question)
    {
        mDatabaseRef.Child("question").Child(world).Child(chap).Child(oldDifficulty).Child(question.UniqueKey).SetValueAsync(null);
        AddNewQuestion(world, chap, newDifficulty, question.question);
    }

    public void getQuestion(string world, string chap, string difficulty, System.Action<GetQuestion[]> callback)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("question").Child(world).Child(chap).Child(difficulty)
      .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              Debug.Log("Code Runs");
              
              DataSnapshot snapshot = task.Result;

              
              int index = 0;
              GetQuestion[] questionList = new GetQuestion[100];
              foreach (DataSnapshot s in snapshot.Children)
              {
                  questionList[index] = new GetQuestion();
                  questionList[index].UniqueKey = s.Key;
                  questionList[index++].question = JsonUtility.FromJson<UploadQuestion>(s.GetRawJsonValue());


                  //Debug.Log("Key: " + questionList[index - 1].UniqueKey);
                  //Debug.Log("Question: " + questionList[index - 1].question.question);

              }

              callback(questionList);
              Debug.Log("Code End");
          }
      });

    }
}
