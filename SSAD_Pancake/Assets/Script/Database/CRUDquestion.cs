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

    public void getQuestion(string world, string chap, string difficulty, System.Action<System.Threading.Tasks.Task> callback)
    {
        
        System.Threading.Tasks.Task Task;
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
              Task = task;
              if (callback!=null)
              {
                  callback(Task);
              }
              Debug.Log("Code Runs");
              
              DataSnapshot snapshot = task.Result;

              
              int index = 0;
              GetQuestion[] questionList = new GetQuestion[100];
              foreach (DataSnapshot s in snapshot.Children)
              {
                  questionList[index] = new GetQuestion();
                  questionList[index].UniqueKey = s.Key;
                  questionList[index++].question = JsonUtility.FromJson<UploadQuestion>(s.GetRawJsonValue());


                  Debug.Log("Key: " + questionList[index - 1].UniqueKey);
                  Debug.Log("Question: " + questionList[index - 1].question.question);

              }
             
              Debug.Log("Code End");
          }
      });

    }
}
