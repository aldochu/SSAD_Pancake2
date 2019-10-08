using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class QuestionSpawner : MonoBehaviour
{
    public int NumQuestions;
    public string world;
    public string chap;
    public string difficulty;
    public Text txt;
    private DatabaseReference mDatabaseRef;

    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        //txt.text = "Test";
       coroutine = generateQuestions();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator generateQuestions()
    {
        world = "world1";
        chap = "chap1";
        difficulty = "easy";
       
        var getTask = FirebaseDatabase.DefaultInstance
      .GetReference("question").Child(world).Child(chap).Child(difficulty)
      .GetValueAsync();

        yield return new WaitUntil(() => getTask.IsCompleted || getTask.IsFaulted);

        DataSnapshot snapshot = null;
        if (getTask.IsCompleted)
        {
            snapshot = getTask.Result;
        }
        
        GetQuestion[] questionList = new GetQuestion[100];
        int index = 0;
        foreach (DataSnapshot s in snapshot.Children)
        {
            questionList[index] = new GetQuestion();
            questionList[index].UniqueKey = s.Key;
            questionList[index++].question = JsonUtility.FromJson<UploadQuestion>(s.GetRawJsonValue());

            Debug.Log("Key: " + questionList[index - 1].UniqueKey);
            Debug.Log("Question: " + questionList[index - 1].question.question);
        }
        txt.text = questionList[0].question.question;
    }
    
}
