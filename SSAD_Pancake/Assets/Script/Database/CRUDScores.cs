using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class CRUDScores : MonoBehaviour
{
    private DatabaseReference mDatabaseRef;
    private int threshold = 10000;
    public StudentScores[] OrderedScoreList;
    public Dictionary<string, double> passingRateDict;
    public Dictionary<string, int> totalAttemptDict;

    // Start is called before the first frame update

    void Start()
    {
        // Set this before calling into the realtime database.
        /*FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");*/

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssad-c9270.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        //RandomlyGenerateScores();
    }

    public void RandomlyGenerateScores()
    {
        StudentScores newScore = new StudentScores();

        for (int k = 0; k < 20; k++)
        {
            newScore.name = "student" + Random.Range(0, 10000);
            newScore.scores = Random.Range(0, 100000);
            newScore.attempt = Random.Range(1, 3);
            AddNewScores("world1", "chap1", "easy", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores("world1", "chap1", "normal", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores("world1", "chap1", "hard", "userid"+ Random.Range(0, 10000) , newScore);

        }
    }

    public void AddNewScores(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {


        string json = JsonUtility.ToJson(studentscore);


        mDatabaseRef.Child("scores").Child(world).Child(chap).Child(difficulty).Child(userid).SetRawJsonValueAsync(json);
    }

    public void getLeaderBoard(string world, string chap, string difficulty, System.Action<bool> callback)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("scores").Child(world).Child(chap).Child(difficulty).OrderByChild("scores")
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {

              Debug.Log("Code Runs");
              DataSnapshot snapshot = task.Result;
              OrderedScoreList = new StudentScores[12];
              for (int i = 0; i < 12; i++)
              {
                  OrderedScoreList[i] = new StudentScores();
              }

              int index = 0;
              //currently order is ascending
              StudentScores[] scoresList = new StudentScores[200];
              foreach (DataSnapshot s in snapshot.Children)
              {
                  Debug.Log(index+s.GetRawJsonValue());
                  scoresList[index] = new StudentScores();
                  scoresList[index++] = JsonUtility.FromJson<StudentScores>(s.GetRawJsonValue());
              }
                Debug.Log(index);
            //   StudentScores[] OrderedScoreList = new StudentScores[index];
              for (int i = 0; i < 12 && i<index; i++)
              {
                  OrderedScoreList[i] = scoresList[index-i-1];
                  Debug.Log("Score: " + OrderedScoreList[i].name);
              }

              callback(true);
              Debug.Log("Code End");
         }
      });
    }


    public void getUserScore(string world, string chap, string difficulty, string userid, System.Action<StudentScores> callback)
    {
        FirebaseDatabase.DefaultInstance
    .GetReference("scores").Child(world).Child(chap).Child(difficulty).Child(userid)
    .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;

            StudentScores studentScore = new StudentScores();

            studentScore = JsonUtility.FromJson<StudentScores>(snapshot.GetRawJsonValue());

            //need to check whether it exist in database
            if (studentScore == null)
            {
                Debug.Log("it's null");
                callback(null);
            }
            else
            {
                Debug.Log("attemp:" + studentScore.attempt + "  , name is: " + studentScore.name + "  , score: " + studentScore.scores);
                callback(studentScore);
            }
                
        }
      });

    }

    public void updateUserScore(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {


        string json = JsonUtility.ToJson(studentscore);


        mDatabaseRef.Child("scores").Child(world).Child(chap).Child(difficulty).Child(userid).SetRawJsonValueAsync(json);
    }

    public void getStatistics(string world)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("scores").Child(world)
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {

              Debug.Log("Code Runs");
              DataSnapshot snapshot = task.Result;
              
              passingRateDict = new Dictionary<string, double>();
              totalAttemptDict = new Dictionary<string, int>();

              foreach (DataSnapshot chapter in snapshot.Children)
              {
                foreach (DataSnapshot mode in chapter.Children ){
                    int passCount = 0;
                    int totalCount = 0;
                    int totalAttempt = 0;
                    foreach (DataSnapshot s in mode.Children ){
                        Debug.Log(s.Key);
                        Debug.Log(s.GetRawJsonValue());
                        if (System.Convert.ToInt32(s.Child("scores").GetRawJsonValue()) > threshold){
                            passCount ++;
                        }
                        totalCount ++;
                        totalAttempt += System.Convert.ToInt32(s.Child("attempt").GetRawJsonValue());   
                    }
                    Debug.Log(chapter.Key+mode.Key);
                    passingRateDict[chapter.Key+mode.Key] = (double) passCount / (double) totalCount;
                    totalAttemptDict[chapter.Key+mode.Key] = totalAttempt;
                  }
                }

              Debug.Log("Code End");
         }
      });
    }
 }
