using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public string LevelName { get; set; }
    public bool Completed { get; set; }
    public bool Locked { get; set; }
    public string world;
    public string chap;
    public string difficulty;
    private DatabaseReference mDatabaseRef;

    public Button game1, game2, game3, game4;
    int levelPassed;

    public GameLogic(string levelName, bool completed, int stars, bool locked)
    {
        this.LevelName = levelName;
        this.Completed = completed;
        this.Locked = locked;

    }

    public void Complete()
    {
        this.Completed = true;
    }
    

    public void Lock()
    {
        this.Locked = true;
    }
    public void unLock()
    {
        this.Locked = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssad-c9270.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        levelPassed = PlayerPrefs.GetInt("Level Passed");


        //switch (levelPassed)
        //{
        //    case 1:
        //        game2.interactable = true;
        //        game3.interactable = true;
        //        game4.interactable = true;
        //        break;
        //    case 2:
        //        game3.interactable = true;
        //        game4.interactable = true;
        //        break;
        //    case 3:
        //        game4.interactable = true;
        //        break;
        //}
    }

    
    public void resetPlayerPrefs()
    {
        game1.interactable = true;
        game2.interactable = true;
        game3.interactable = true;
        game4.interactable = true;
        PlayerPrefs.DeleteAll();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
