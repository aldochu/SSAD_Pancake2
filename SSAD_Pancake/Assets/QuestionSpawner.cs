using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.SceneManagement;

public class QuestionSpawner : MonoBehaviour
{
    
    public AudioSource point;
    public AudioSource fail;
    public int NumQuestions;
    public string world;// = StaticVariable.world;
    public string chap;// = StaticVariable.chapter;
    public string difficulty;// = StaticVariable.difficulty;
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text Score;
    private DatabaseReference mDatabaseRef;
    int userChoice = 1;
    int score = 0;
    private IEnumerator coroutine;
    public GameObject startButton;
    public GameObject hero1;
    public GameObject hero1fall;
    public GameObject hero2;
    public GameObject hero2fall;
    public GameObject hero3;
    public GameObject hero3fall;
    StudentScores scoreList;
    bool call = false;
    int character;
    CRUDScores crudscore;

    /* Change this */
    string userID = "userid1159";// StaticVariable.UserID;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        character = StaticVariable.characterSelect;
        setCharacterMovement(character, false);
        Time.timeScale = 0;
        crudscore = GetComponent<CRUDScores>();
        crudscore.getUserScore(world, chap, difficulty, userID, callbackFunc);
        yield return new WaitUntil(() => call==true);
  
       // Debug.Log(scoreList.scores);
        // Set this before calling into the realtime database.
       // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssad-c9270.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        Score.text = "0";
        // point = GetComponent<AudioSource>();
        
        coroutine = GenerateQuestions();
        StartCoroutine(coroutine);
    }
    public void BackToCharacterSelection()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void setCharacterMovement(int heroNumber, bool falldown)
    {
        hero1.SetActive(false);
        hero1fall.SetActive(false);
        hero2.SetActive(false);
        hero2fall.SetActive(false);
        hero3.SetActive(false);
        hero3fall.SetActive(false);
        if (heroNumber==1)
        {
            if (falldown)
            {
                hero1.SetActive(false);
                hero1fall.SetActive(true);
            }
            else
            {
                hero1.SetActive(true);
                hero1fall.SetActive(false);
            }
            
        }
        else if (heroNumber== 2)
        {
            if (falldown)
            {
                hero2.SetActive(false);
                hero2fall.SetActive(true);
            }
            else
            {
                hero2.SetActive(true);
                hero2fall.SetActive(false);
            }
        }
        else
        {
            if (falldown)
            {
                hero3.SetActive(false);
                hero3fall.SetActive(true);
            }
            else
            {
                hero3.SetActive(true);
                hero3fall.SetActive(false);
            }
        }

    }
    public void startGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
        if (difficulty == "normal")
        {
            Time.timeScale = 1.1f;
        }
        if (difficulty == "hard")
        {
            Time.timeScale = 1.3f;
        }
    }
    public void playerMoveQn1()
    {
        userChoice = 1;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = new Vector3(-7f, -1.6f, 0);
        }
        hero1fall.transform.position = new Vector3(-7f, -1.6f, 0);
        hero2fall.transform.position = new Vector3(-7f, -1.6f, 0);
        hero3fall.transform.position = new Vector3(-7f, -1.6f, 0);
        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7f, -1.6f, 0);
        HeroFall.transform.position = new Vector3(-7f, -1.6f, 0);*/
    }
    public void playerMoveQn2()
    {
        userChoice = 2;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = new Vector3(-7f, -2.7f, 0);
        }
        hero1fall.transform.position = new Vector3(-7f, -2.7f, 0);
        hero2fall.transform.position = new Vector3(-7f, -2.7f, 0);
        hero3fall.transform.position = new Vector3(-7f, -2.7f, 0);
        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7f, -2.7f, 0);
        HeroFall.transform.position = new Vector3(-7f, -2.7f, 0);
        */
    }
    public void playerMoveQn3()
    {
        userChoice = 3;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = new Vector3(-7f, -3.8f, 0);
        }
        hero1fall.transform.position = new Vector3(-7f, -3.8f, 0);
        hero2fall.transform.position = new Vector3(-7f, -3.8f, 0);
        hero3fall.transform.position = new Vector3(-7f, -3.8f, 0);

        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7f, -3.8f, 0);
        HeroFall.transform.position = new Vector3(-7f, -3.8f, 0);*/
    }
    public void playerMoveQn4()
    {
        userChoice = 4;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = new Vector3(-7f, -4.9f, 0);
        }
        hero1fall.transform.position = new Vector3(-7f, -4.9f, 0);
        hero2fall.transform.position = new Vector3(-7f, -4.9f, 0);
        hero3fall.transform.position = new Vector3(-7f, -4.9f, 0);


        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7f, -4.9f, 0);
        HeroFall.transform.position = new Vector3(-7f, -4.9f, 0);*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    bool CheckIfQuestionInArray(int question, int[] array)
    {
        foreach (var item in array)
        {
            if (question == item)
            {
                return true;
            }
        }
        return false;
    }
    
    
    public void callbackFunc(StudentScores scList)
    {
        scoreList = scList;
        call = true;
    }
    IEnumerator GenerateQuestions()
    {
        var getTask = FirebaseDatabase.DefaultInstance
      .GetReference("question").Child(world).Child(chap).Child(difficulty)
      .GetValueAsync();

        yield return new WaitUntil(() => getTask.IsCompleted || getTask.IsFaulted);

        DataSnapshot snapshot = null;
        if (getTask.IsCompleted)
        {
            snapshot = getTask.Result;
        }

        int totalQuestion = int.Parse(snapshot.ChildrenCount.ToString());
        if (NumQuestions > totalQuestion) //If not enough questions from the database
        {
            question.text = "The lecturer has not set enough question for this chapter.";
            Time.timeScale = 0;
        }
        else
        {
            GetQuestion[] questionList = new GetQuestion[snapshot.ChildrenCount];
            int index = 0;
            //Get question list
            foreach (DataSnapshot s in snapshot.Children)
            {
                questionList[index] = new GetQuestion();
                questionList[index].UniqueKey = s.Key;
                questionList[index++].question = JsonUtility.FromJson<UploadQuestion>(s.GetRawJsonValue());
            }

            GetQuestion[] randomQuestion = new GetQuestion[NumQuestions];
            for (int i = 0; i < NumQuestions; i++)
            {
                randomQuestion[i] = questionList[i];
                while (randomQuestion[i] == null)
                {
                    int random = Random.Range(0, NumQuestions - 1);
                    if (questionList[random] != null)
                    {
                        randomQuestion[i] = questionList[random];
                        questionList[random] = null;
                    }
                }
            }


            int rightOption = 0;
            for (int i = 0; i < NumQuestions; i++)
            {
                
                question.text = randomQuestion[i].question.question;
                int random = Random.Range(1, 4);
                if (random == 1)
                {
                    answer1.text = randomQuestion[i].question.ans1;
                    answer2.text = randomQuestion[i].question.ans2;
                    answer3.text = randomQuestion[i].question.ans3;
                    answer4.text = randomQuestion[i].question.ans4;
                }
                else if (random == 2)
                {
                    answer1.text = randomQuestion[i].question.ans2;
                    answer2.text = randomQuestion[i].question.ans3;
                    answer3.text = randomQuestion[i].question.ans1;
                    answer4.text = randomQuestion[i].question.ans4;
                }
                else if (random == 3)
                {
                    answer1.text = randomQuestion[i].question.ans3;
                    answer2.text = randomQuestion[i].question.ans2;
                    answer3.text = randomQuestion[i].question.ans4;
                    answer4.text = randomQuestion[i].question.ans1;
                }
                else
                {
                    answer1.text = randomQuestion[i].question.ans3;
                    answer2.text = randomQuestion[i].question.ans1;
                    answer3.text = randomQuestion[i].question.ans4;
                    answer4.text = randomQuestion[i].question.ans2;
                }

                string rightAnswer = randomQuestion[i].question.correctAns;

                if (rightAnswer == answer1.text)
                {
                    rightOption = 1;
                }
                else if (rightAnswer == answer2.text)
                {
                    rightOption = 2;
                }
                else if (rightAnswer == answer3.text)
                {
                    rightOption = 3;
                }
                else if (rightAnswer == answer4.text)
                {
                    rightOption = 4;
                }
                yield return new WaitForSeconds(4.2f);
                if (rightOption == userChoice)
                {
                    score++;
                    Score.text = score.ToString();
                    point.Play();
                    // playSound();
                    yield return new WaitForSeconds(1.8f);
                }
                else
                {
                    setCharacterMovement(character, true);
                    
                    fail.Play();
                    yield return new WaitForSeconds(0.6f);
                    setCharacterMovement(character, false);
                    yield return new WaitForSeconds(1.2f);
                }
                
            }
            // GETTING attempt  from scores
            
            int latestAttempt = 0;
            /* var task = FirebaseDatabase.DefaultInstance
      .GetReference("scores").Child(world).Child(chap).Child(difficulty).Child(userID)
      .GetValueAsync();

             yield return new WaitUntil(() => task.IsCompleted || task.IsFaulted);


             if (task.IsFaulted)
             {
                 Debug.Log("Failed to connect");
                 // Handle the error...
             }
             else if (task.IsCompleted)
             {

                 Debug.Log("Code Runs");
                 snapshot = task.Result;


                 index = 0;

                 //currently order is ascending
                 StudentScores[] scoresList = new StudentScores[snapshot.ChildrenCount];

                 foreach (DataSnapshot s in snapshot.Children)
                 {
                     scoresList[index] = new StudentScores();
                     scoresList[index++] = JsonUtility.FromJson<StudentScores>(s.GetRawJsonValue());
                 }

                 Debug.Log("Total record found " + snapshot.ChildrenCount);


                 foreach (var item in scoresList)
                 {
                     if (item != null)
                     {
                         //get the student name here
                         if (item.attempt > latestAttempt)
                         {
                             latestAttempt = item.attempt;
                         }

                         if (item.scores > score)
                         {
                             score = item.scores;
                         }
                     }
                 }
             //}*/
            // To Insert student score into DB
            Debug.Log(scoreList.scores);
            if (scoreList!=null)
            {
                if (scoreList.scores > score)
                {
                    score = scoreList.scores;
                }
                latestAttempt = scoreList.attempt;
            }

            
            crudscore.getUserScore(world, chap, difficulty, userID, callbackFunc);


            StudentScores sc = new StudentScores();
            
            sc.name = "";
            sc.attempt = latestAttempt+1;
            sc.scores = score;
            crudscore.updateUserScore(world, chap, difficulty, userID, sc);
            
            Time.timeScale = 0;
            question.text = "Game Completed! Click back to attempt another game!";
        }

    }
   

}
