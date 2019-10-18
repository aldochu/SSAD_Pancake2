using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public string LevelName { get; set; }
    public bool Completed { get; set; }
    public int Stars { get; set; }
    public bool Locked { get; set; }
    public Text chapterName;
    
    //Chapter 1
    public GameObject chapter1EasyStar, chapter1MediumStar, chapter1HardStar, chapter1Panel;
    public Button chapter1EasyButton, chapter1MediumButton, chapter1HardButton;
    //Chapter 2
    public GameObject chapter2EasyStar, chapter2MediumStar, chapter2HardStar, chapter2Panel;
    public Button chapter2EasyButton, chapter2MediumButton, chapter2HardButton;
    //Chapter 3
    public GameObject chapter3EasyStar, chapter3MediumStar, chapter3HardStar, chapter3Panel;
    public Button chapter3EasyButton, chapter3MediumButton, chapter3HardButton;
    //Chapter 4
    public GameObject chapter4EasyStar, chapter4MediumStar, chapter4HardStar, chapter4Panel;
    public Button chapter4EasyButton, chapter4MediumButton, chapter4HardButton;
    

    public bool gotComplete;
    
    private string chap, world, difficulty, userid;
    private string _chap, _world, _difficulty;
    private CRUDScores crudscore;
    public Text UItext;
    private bool callbackdone = false;
    private StudentScores studentScores;
    int levelPassed;

    bool chapter1Easybutton, chapter1Mediumbutton, chapter1Hardbutton, chapter1Easystar, chapter1Mediumstar, chapter1Hardstar;
    bool chapter2Easybutton, chapter2Mediumbutton, chapter2Hardbutton, chapter2Easystar, chapter2Mediumstar, chapter2Hardstar;
    bool chapter3Easybutton, chapter3Mediumbutton, chapter3Hardbutton, chapter3Easystar, chapter3Mediumstar, chapter3Hardstar;
    bool chapter4Easybutton, chapter4Mediumbutton, chapter4Hardbutton, chapter4Easystar, chapter4Mediumstar, chapter4Hardstar;

    public GameObject game1Unlock, game1lock, game2Unlock, game2lock, game3Unlock, game3lock, game4Unlock, game4lock;


    public void ShowChapterOnePanelGame1()
    {
        if(StaticVariable.game1 == true)
        {
            chapter1Panel.SetActive(true);
            chapter1EasyButton.interactable = chapter1Easybutton;
            chapter1EasyStar.SetActive(chapter1Easystar);
            chapter1MediumButton.interactable = chapter1Mediumbutton;
            chapter1MediumStar.SetActive(chapter1Mediumstar);
            chapter1HardButton.interactable = chapter1Hardbutton;
            chapter1HardStar.SetActive(chapter1Hardstar);

            /*
            chapter1EasyButton.interactable = true;
            chapter1EasyStar.SetActive(false);
            chapter1MediumButton.interactable = false;
            chapter1MediumStar.SetActive(false);
            chapter1HardButton.interactable = false;
            chapter1HardStar.SetActive(false);
            */
        }

    }
    public void ShowChapterOnePanelGame2()
    {
        if (StaticVariable.game2 == true)
        {
            chapter2Panel.SetActive(true);
            chapter2EasyButton.interactable = chapter2Easybutton;
            chapter2EasyStar.SetActive(chapter2Easystar);
            chapter2MediumButton.interactable = chapter2Mediumbutton;
            chapter2MediumStar.SetActive(chapter2Mediumstar);
            chapter2HardButton.interactable = chapter2Hardbutton;
            chapter2HardStar.SetActive(chapter2Hardstar);

            /*
            chapter2EasyButton.interactable = true;
            chapter2EasyStar.SetActive(false);
            chapter2MediumButton.interactable = false;
            chapter2MediumStar.SetActive(false);
            chapter2HardButton.interactable = false;
            chapter2HardStar.SetActive(false);
            */
        }
        else
        {
            chapter2Panel.SetActive(false);
        }
    }
    public void ShowChapterOnePanelGame3()
    {
        if (StaticVariable.game3 == true)
        {
            chapter3Panel.SetActive(true);
            chapter3EasyButton.interactable = chapter3Easybutton;
            chapter3EasyStar.SetActive(chapter3Easystar);
            chapter3MediumButton.interactable = chapter3Mediumbutton;
            chapter3MediumStar.SetActive(chapter3Mediumstar);
            chapter3HardButton.interactable = chapter3Hardbutton;
            chapter3HardStar.SetActive(chapter3Hardstar);
            /*
            chapter3EasyButton.interactable = true;
            chapter3EasyStar.SetActive(false);
            chapter3MediumButton.interactable = false;
            chapter3MediumStar.SetActive(false);
            chapter3HardButton.interactable = false;
            chapter3HardStar.SetActive(false);
            */
        }
        else
        {
            chapter3Panel.SetActive(false);
        }
    }
    public void ShowChapterOnePanelGame4()
    {
        if (StaticVariable.game4 == true)
        {
            chapter4Panel.SetActive(true);
            chapter4EasyButton.interactable = chapter4Easybutton;
            chapter4EasyStar.SetActive(chapter4Easystar);
            chapter4MediumButton.interactable = chapter4Mediumbutton;
            chapter4MediumStar.SetActive(chapter4Mediumstar);
            chapter4HardButton.interactable = chapter4Hardbutton;
            chapter4HardStar.SetActive(chapter4Hardstar);
            /*
            chapter4EasyButton.interactable = true;
            chapter4EasyStar.SetActive(false);
            chapter4MediumButton.interactable = false;
            chapter4MediumStar.SetActive(false);
            chapter4HardButton.interactable = false;
            chapter4HardStar.SetActive(false);
            */
        }
        else
        {
            chapter4Panel.SetActive(false);
        }
    }


    public game(string levelName, bool completed, int stars, bool locked)
    {
        this.LevelName = levelName;
        this.Completed = completed;
        this.Stars = stars;
        this.Locked = locked;
    }

    public void Complete()
    {
        this.Completed = true;
    }
    public void Complete(int stars)
    {
        this.Completed = true;
        this.Stars = stars;
    }

    public void Lock()
    {
        this.Locked = true;
    }
    public void unLock()
    {
        this.Locked = false;
    }
    void lockedOrNot()
    {

        if (StaticVariable.game1 == true)
        {
            game1Unlock.SetActive(true);
            game1lock.SetActive(false);
        }
        else
        {
            game1lock.SetActive(true);
            game1Unlock.SetActive(false);
        }
        if (StaticVariable.game2 == true)//StaticVariable.game1 == true && 
        {
            game2Unlock.SetActive(true);
            game2lock.SetActive(false);
        }
        else if(StaticVariable.game2 == false)//StaticVariable.game1 == true && 
        {
            game2lock.SetActive(true);
            game2Unlock.SetActive(false);
        }

        if (StaticVariable.game3 == true)//StaticVariable.game1 == true && StaticVariable.game2 == true && 
        {
            game3Unlock.SetActive(true);
            game3lock.SetActive(false);
        }
        else if (StaticVariable.game3 == false)//StaticVariable.game1 == true && StaticVariable.game2 == false && 
        {
            game3lock.SetActive(true);
            game3Unlock.SetActive(false);
        }

        if(StaticVariable.game4 == true)//StaticVariable.game1 == true && StaticVariable.game2 == true && StaticVariable.game3 == true && 
        {
            game4Unlock.SetActive(true);
            game4lock.SetActive(false);
        }
        else if (StaticVariable.game4 == false)//StaticVariable.game1 == true && StaticVariable.game2 == true && StaticVariable.game3 == false && 
        {
            game4lock.SetActive(true);
            game4Unlock.SetActive(false);
        }

    }

    // Start is called before the first frame update
    //
    void Start()
    {
        chapter1Panel.SetActive(false);
        chapter2Panel.SetActive(false);
        chapter3Panel.SetActive(false);
        chapter4Panel.SetActive(false);
        lockedOrNot();
        var difficultyLevel = new List<string> { "easy", "medium", "hard" };
        var chapterLevel = new List<string> { "chap1", "chap2", "chap3", "chap4" };
        userid = "userid1159";
        world = "world1";
        crudscore = GetComponent<CRUDScores>();
        foreach (string i in chapterLevel)
        {
            foreach(string d in difficultyLevel)
            {
                Debug.Log(i+" "+d);
                chap = i;
                difficulty = d;
                crudscore.getUserScore(world, chap, difficulty, userid, myCallbackFunction);

                Debug.Log(callbackdone);
                //Debug.Log(studentScores.scores);
                //getStudentScores(world, i, userid, d);
                
            }
        }
        /*
        chap = "chap1";
        world = "world1";
        difficulty = "easy";
        userid = "userid1159";
        crudscore = GetComponent<CRUDScores>();
        crudscore.getUserScore(world, chap, difficulty, userid, myCallbackFunction);
        
        getStudentScores(world, chap, userid, difficulty);
        callbackdone = false;
        */
        
        
    }
    

    //IEnumerator Start() 
    ////IEnumerator Start()
    //{
    //    //chap = "chap1";
    //    //world = "world1";
    //    //userid = "userid1159";
    //    //difficulty = "easy";


    //    crudScores = GetComponent<CRUDScores>();
    //    crudScores.getUserScore(world, chap, difficulty, userid, callbackFunc);

    //    Debug.Log(callBack);
    //    yield return new WaitUntil(() => callBack == true);
    //    //Debug.Log(studentScores.scores);
    //    Debug.Log(callBack);
    //    while (callBack == true)
    //    {
    //        getStudentScores(world, chap, userid, difficulty);
    //        callBack = false;
    //    
    //}
    // Update is called once per frame

    void Update()
    {
        if (callbackdone)
        {
            //UItext.text = "my name: " + studentScores.name + " , my Score: " + studentScores.scores.ToString();
            callbackdone = false;
        }
        lockedOrNot();
    }

    public void getStudentScores(string world, string chap, string userid, string difficulty)
    {
        
        if (difficulty == "easy")
        {
            Debug.Log(studentScores.scores);
            switch (chap)
            {
                case "chap1":
                    if (studentScores.scores > (StaticVariable.easy / 2))//User passed
                    {
                        Debug.Log("I am here");
                        chapter1Easybutton = true;
                        chapter1Mediumbutton = true;
                        chapter1Hardbutton = false;
                        chapter1Easystar = true;
                        chapter1Mediumstar = false;
                        chapter1Hardstar = false;
                        /*
                        chapter1EasyButton.interactable = true;
                        chapter1EasyStar.SetActive(true);
                        Debug.Log("Easy star active");
                        
                        gotComplete = true;
                        //can go to next level
                        chapter1MediumButton.interactable = true;
                        chapter1MediumStar.SetActive(false);
                        //can't go to the next next level
                        chapter1HardButton.interactable = false;
                        chapter1HardStar.SetActive(false);
                        
                        gotComplete = true;
                        */
                    }
                    else//User Failed
                    {
                        chapter1Easybutton = false;
                        chapter1Mediumbutton = false;
                        chapter1Hardbutton = false;
                        chapter1Easystar = false;
                        chapter1Mediumstar = false;
                        chapter1Hardstar = false;
                        /*
                        chapter1EasyStar.SetActive(false);
                        chapter1EasyButton.interactable = false;
                        gotComplete = false;
                        chapter1MediumStar.SetActive(false);
                        chapter1MediumButton.interactable = false;
                        gotComplete = false;
                        chapter1HardStar.SetActive(false);
                        chapter1HardButton.interactable = false;
                        gotComplete = false;
                        */

                    }
                    break;
                case "chap2":
                    if (studentScores.scores > StaticVariable.easy / 2)//User passed
                    {
                        chapter2Easybutton = true;
                        chapter2Mediumbutton = true;
                        chapter2Hardbutton = false;
                        chapter2Easystar = true;
                        chapter2Mediumstar = false;
                        chapter2Hardstar = false;
                        /*
                        chapter2EasyStar.SetActive(true);
                        chapter2EasyButton.interactable = true;
                        gotComplete = true;
                        //can go to next level
                        chapter2MediumButton.interactable = true;
                        chapter2MediumStar.SetActive(false);
                        //can't go to the next next level
                        chapter2HardStar.SetActive(false);
                        chapter2HardButton.interactable = false;
                        */
                    }
                    else//User Failed
                    {
                        chapter2Easybutton = false;
                        chapter2Mediumbutton = false;
                        chapter2Hardbutton = false;
                        chapter2Easystar = false;
                        chapter2Mediumstar = false;
                        chapter2Hardstar = false;
                        /*
                        chapter2EasyStar.SetActive(false);
                        chapter2EasyButton.interactable = false;
                        gotComplete = false;
                        chapter2MediumStar.SetActive(false);
                        chapter1MediumButton.interactable = false;
                        gotComplete = false;
                        chapter2HardStar.SetActive(false);
                        chapter2HardButton.interactable = false;
                        gotComplete = false;
                        */
                    }
                    break;
                case "chap3":
                    if (studentScores.scores > StaticVariable.easy / 2)//User passed
                    {
                        chapter3Easybutton = true;
                        chapter3Mediumbutton = true;
                        chapter3Hardbutton = false;
                        chapter3Easystar = true;
                        chapter3Mediumstar = false;
                        chapter3Hardstar = false;
                        /*
                        chapter3EasyStar.SetActive(true);
                        chapter3EasyButton.interactable = true;
                        gotComplete = true;
                        //can go to next level
                        chapter3MediumButton.interactable = true;
                        chapter3MediumStar.SetActive(false);
                        //can't go to the next next level
                        chapter3HardStar.SetActive(false);
                        chapter3HardButton.interactable = false;
                        */
                    }
                    else//User Failed
                    {
                        chapter3Easybutton = false;
                        chapter3Mediumbutton = false;
                        chapter3Hardbutton = false;
                        chapter3Easystar = false;
                        chapter3Mediumstar = false;
                        chapter3Hardstar = false;
                        /*
                        chapter3EasyStar.SetActive(false);
                        chapter3EasyButton.interactable = false;
                        gotComplete = false;
                        chapter3MediumStar.SetActive(false);
                        chapter3MediumButton.interactable = false;
                        gotComplete = false;
                        chapter3HardStar.SetActive(false);
                        chapter3HardButton.interactable = false;
                        gotComplete = false;
                        */
                    }
                    break;
                case "chap4":
                    if (studentScores.scores > StaticVariable.easy / 2)//User passed
                    {
                        chapter4Easybutton = true;
                        chapter4Mediumbutton = true;
                        chapter4Hardbutton = false;
                        chapter4Easystar = true;
                        chapter4Mediumstar = false;
                        chapter4Hardstar = false;
                        /*
                        chapter4EasyStar.SetActive(true);
                        chapter4EasyButton.interactable = true;
                        gotComplete = true;
                        //can go to next level
                        chapter4MediumButton.interactable = true;
                        chapter4MediumStar.SetActive(false);
                        //can't go to the next next level
                        chapter4HardStar.SetActive(false);
                        chapter4HardButton.interactable = false;
                        */
                    }
                    else//User Failed
                    {
                        chapter4Easybutton = false;
                        chapter4Mediumbutton = false;
                        chapter4Hardbutton = false;
                        chapter4Easystar = false;
                        chapter4Mediumstar = false;
                        chapter4Hardstar = false;
                        /*
                        chapter4EasyStar.SetActive(false);
                        chapter4EasyButton.interactable = false;
                        gotComplete = false;
                        chapter4MediumStar.SetActive(false);
                        chapter4MediumButton.interactable = false;
                        gotComplete = false;
                        chapter4HardStar.SetActive(false);
                        chapter4HardButton.interactable = false;
                        gotComplete = false;
                        */
                    }
                    break;
            }
            
        }
        else if (difficulty == "medium")
        {
            switch (chap)
            {
                case "chap1":
                    if (studentScores.scores > StaticVariable.medium / 2)//User passed
                    {
                        chapter1Mediumbutton = true;
                        chapter1Hardbutton = true;
                        chapter1Mediumstar = true;
                        chapter1Hardstar = false;
                        /*
                        chapter1MediumStar.SetActive(true);
                        chapter1MediumButton.interactable = true;
                        gotComplete = true;
                        //can go to next level
                        chapter1HardStar.SetActive(false);
                        chapter1HardButton.interactable = true;
                        gotComplete = true;
                        */
                    }
                    else
                    {
                        chapter1Mediumbutton = false;
                        chapter1Hardbutton = false;
                        chapter1Mediumstar = false;
                        chapter1Hardstar = false;
                        /*
                        chapter1MediumStar.SetActive(false);
                        chapter1MediumButton.interactable = false;
                        gotComplete = false;
                        chapter1HardStar.SetActive(false);
                        chapter1HardButton.interactable = false;
                        gotComplete = false;
                        */
                    }
                    break;
                case "chap2":
                    if (studentScores.scores > StaticVariable.medium / 2)//User passed
                    {
                        chapter2Mediumbutton = true;
                        chapter2Hardbutton = true;
                        chapter2Mediumstar = true;
                        chapter2Hardstar = false;
                        /*
                        chapter2MediumStar.SetActive(true);
                        chapter2MediumButton.interactable = true;
                        gotComplete = true;
                        //can go to next level
                        chapter2HardStar.SetActive(false);
                        chapter2HardButton.interactable = true;
                        */
                    }
                    else
                    {
                        chapter2Mediumbutton = false;
                        chapter2Hardbutton = false;
                        chapter2Mediumstar = false;
                        chapter2Hardstar = false;
                        /*
                        chapter2MediumStar.SetActive(false);
                        chapter2MediumButton.interactable = false;
                        gotComplete = false;
                        chapter2HardStar.SetActive(false);
                        chapter2HardButton.interactable = false;
                        gotComplete = false;
                        */
                    }
                    break;
                case "chap3":
                    if (studentScores.scores > StaticVariable.medium / 2)//User passed
                    {
                        chapter3Mediumbutton = true;
                        chapter3Hardbutton = true;
                        chapter3Mediumstar = true;
                        chapter3Hardstar = false;
                        /*
                        chapter3MediumStar.SetActive(true);
                        chapter3MediumButton.interactable = true;
                        gotComplete = true;
                        //can go to next level
                        chapter3HardStar.SetActive(false);
                        chapter3HardButton.interactable = true;
                        */
                    }
                    else
                    {
                        chapter3Mediumbutton = false;
                        chapter3Hardbutton = false;
                        chapter3Mediumstar = false;
                        chapter3Hardstar = false;
                        /*
                        chapter3MediumStar.SetActive(false);
                        chapter3MediumButton.interactable = false;
                        gotComplete = false;
                        chapter3HardStar.SetActive(false);
                        chapter3HardButton.interactable = false;
                        gotComplete = false;
                        */
                    }
                    break;
                case "chap4":
                    if (studentScores.scores > StaticVariable.medium / 2)//User passed
                    {
                        chapter4Mediumbutton = true;
                        chapter4Hardbutton = true;
                        chapter4Mediumstar = true;
                        chapter4Hardstar = false;
                        /*
                        chapter4MediumStar.SetActive(true);
                        chapter4MediumButton.interactable = true;
                        gotComplete = true;
                        //can go to next level
                        chapter4HardStar.SetActive(false);
                        chapter4HardButton.interactable = true;
                        */
                    }
                    else
                    {
                        chapter4Mediumbutton = false;
                        chapter4Hardbutton = false;
                        chapter4Mediumstar = false;
                        chapter4Hardstar = false;
                        /*
                        chapter4MediumStar.SetActive(false);
                        chapter4MediumButton.interactable = false;
                        gotComplete = false;
                        chapter4HardStar.SetActive(false);
                        chapter4HardButton.interactable = false;
                        gotComplete = false;
                        */
                    }
                    break;
            }
            

        }
        else if (difficulty == "hard")
        {
            switch (chap)
            {
                case "chap1":
                    if (studentScores.scores > StaticVariable.hard / 2)//User passed
                    {
                        chapter1Hardbutton = true;
                        chapter1Hardstar = true;
                        /*
                        chapter1HardStar.SetActive(true);
                        chapter1HardButton.interactable = true;
                        gotComplete = true;
                        */
                        //game finished
                        StaticVariable.game1 = true;
                    }
                    else
                    {
                        chapter1Hardbutton = false;
                        chapter1Hardstar = false;
                        /*
                        chapter1HardStar.SetActive(false);
                        chapter1HardButton.interactable = false;
                        */
                        gotComplete = false;
                    }
                    break;
                case "chap2":
                    if (studentScores.scores > StaticVariable.hard / 2)//User passed
                    {
                        chapter2Hardbutton = true;
                        chapter2Hardstar = true;
                        /*
                        chapter2HardStar.SetActive(true);
                        chapter2HardButton.interactable = true;
                        */
                        gotComplete = true;
                        StaticVariable.game2 = true;
                    }
                    else
                    {
                        chapter2Hardbutton = false;
                        chapter2Hardstar = false;
                        /*
                        chapter2HardStar.SetActive(false);
                        chapter2HardButton.interactable = false;
                        */
                        gotComplete = false;
                    }
                    break;
                case "chap3":
                    if (studentScores.scores > StaticVariable.hard / 2)//User passed
                    {
                        chapter3Hardbutton = true;
                        chapter3Hardstar = true;
                        /*
                        chapter3HardStar.SetActive(true);
                        chapter3HardButton.interactable = true;
                        */
                        gotComplete = true;
                        StaticVariable.game3 = true;
                    }
                    else
                    {
                        chapter3Hardbutton = false;
                        chapter3Hardstar = false;
                        /*
                        chapter3HardStar.SetActive(false);
                        chapter3HardButton.interactable = false;
                        */
                        gotComplete = false;
                    }
                    break;
                case "chap4":
                    if (studentScores.scores > StaticVariable.hard / 2)//User passed
                    {
                        chapter4Hardbutton = true;
                        chapter4Hardstar = true;
                        /*
                        chapter4HardStar.SetActive(true);
                        chapter4HardButton.interactable = true;
                        */
                        gotComplete = true;
                        StaticVariable.game4 = true;
                    }
                    else
                    {
                        chapter4Hardbutton = false;
                        chapter4Hardstar = false;
                        /*
                        chapter4HardStar.SetActive(false);
                        chapter4HardButton.interactable = false;
                        */
                        gotComplete = false;
                    }
                    break;
            }
            
        }
        


    }
    public void myCallbackFunction(StudentScores myScore, string world, string chap, string difficulty)
    {
        Debug.Log("call back executed");
        if(myScore == null)
        {
            Debug.Log("false");
        }
        else
        {
            this.studentScores = myScore;
            _chap = chap;
            _world = world;
            _difficulty = difficulty;
            Debug.Log(studentScores.scores);
            getStudentScores(_world, _chap, userid, _difficulty);
        }
        callbackdone = true;
    }
    //public void callbackFunc(StudentScores scores)
    //{
    //    Debug.Log("Call back begin");

    //    chap = "chap1";
    //    world = "world1";
    //    difficulty = "easy";
    //    userid = "userid1159";
    //    callBack = true;
    //    Debug.Log(scores.scores);
    //    Debug.Log(callBack);
    //    if (scores == null)
    //    {
    //        gotComplete = false;
    //    }
    //    else
    //    {
    //        this.studentScores = scores;
    //        Debug.Log(studentScores.scores);
    //    }

    //}
}
