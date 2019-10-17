using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forSurabhi : MonoBehaviour
{
    // Start is called before the first frame update

    private string chap, world, difficulty, userid;
    private CRUDScores crudscore;
    public Text UItext, UItext2;
    private bool callbackdone = false;
    private StudentScores myScore;


    private string _chap, _world, _difficulty;
    void Start()
    {
        chap = "chap1";
        world = "world1";
        difficulty = "easy";
        userid = "userid1159";
        crudscore = GetComponent<CRUDScores>();
        crudscore.getUserScore(world, chap, difficulty, userid, myCallbackFunction);
    }

    // Update is called once per frame
    void Update()
    {
        if (callbackdone)
        {
            UItext.text = "my name: " + myScore.name + " , my Score: " + myScore.scores.ToString();
            UItext2.text = "World: " + _world + " , chap: " + _chap + ", level: " + _difficulty; 
            callbackdone = false;
        }
    }

    public void myCallbackFunction(StudentScores myScore, string world, string chap, string difficulty)
    {
        Debug.Log("call back executed");
        this.myScore = myScore;
        _chap = chap;
        _world = world;
        _difficulty = difficulty;
        callbackdone = true;
    }
}
