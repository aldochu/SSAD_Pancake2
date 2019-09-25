﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class CRUDScores : MonoBehaviour
{
    private DatabaseReference mDatabaseRef;
    public StudentScores[] OrderedScoreList = new StudentScores[100];

    // Start is called before the first frame update

    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void RandomlyGenerateScores()
    {
        StudentScores newScore = new StudentScores();

        for (int k = 0; k < 20; k++)
        {
            newScore.name = "student" + Random.Range(0, 10000);
            newScore.scores = Random.Range(0, 100000);
            newScore.attempt = Random.Range(1, 3);

            AddNewScores("world1", "chap1", "hard", "userid"+ Random.Range(0, 10000) , newScore);

        }
    }

    public void AddNewScores(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {


        string json = JsonUtility.ToJson(studentscore);


        mDatabaseRef.Child("scores").Child(world).Child(chap).Child(difficulty).Child(userid).SetRawJsonValueAsync(json);
    }

    public void getLeaderBoard(string world, string chap, string difficulty)
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

              int index = 0;
              //currently order is ascending
              StudentScores[] scoresList = new StudentScores[100];
              foreach (DataSnapshot s in snapshot.Children)
              {
                  Debug.Log(index+s.GetRawJsonValue());
                  scoresList[index] = new StudentScores();
                  scoresList[index++] = JsonUtility.FromJson<StudentScores>(s.GetRawJsonValue());
              }
            //   StudentScores[] OrderedScoreList = new StudentScores[index];
              for (int i = 0; i < index; i++)
              {
                  OrderedScoreList[i] = scoresList[index-i-1];
                  Debug.Log("Score: " + OrderedScoreList[i].name);
              }


              Debug.Log("Code End");
         }
      });
    }
 }