using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class LeaderboardController : MonoBehaviour {

    public List<HighscoreEntry> highscores;

    private string world = "world1";
    private string chapter = "chap1";
    private string mode = "hard";
    public CRUDScores dbClass;
    public bool gotData = false;
    public HighscoreTableTransformer transformer;

    private void Awake() {
        dbClass.getLeaderBoard(world, chapter, mode, callback);
        highscores= new List<HighscoreEntry>(12);
        for (int i = 0; i<12 ;i++){
            highscores.Add(new HighscoreEntry());
        }
        transformer.ConstructTable(highscores);
    }

    public void DropdownValueChanged(Dropdown Dropdown) {
        Debug.Log(Dropdown.options[Dropdown.value].text);
        updateQueryString(Dropdown.options[Dropdown.value].text);
        dbClass.getLeaderBoard(world, chapter, mode, callback);
    }

    public void callback(bool callback){
        gotData = callback;
        Debug.Log(gotData);
    }

    void Update(){
        if (gotData) {
            int i = 0;
            foreach (StudentScores s in dbClass.OrderedScoreList) {
                Debug.Log(string.Format("Key = {0}, Value = {1}", s.scores,s.name));
                highscores[i].score = s.scores;
                highscores[i].name = s.name;
            
                transformer.ModifyTable(highscores[i], i);
                i++;
            }
            gotData = false;
            Debug.Log(gotData);
        }
    }

    public void BackToProfMode()
    {
        Application.LoadLevel("ProfMode");
        
    }

    private void updateQueryString(string rawInput){
        switch(rawInput){
            case "Chapter 1": chapter = "chap1"; break;
            case "Chapter 2": chapter = "chap2"; break;
            case "Chapter 3": chapter = "chap3"; break;
            case "Chapter 4": chapter = "chap4"; break;
            case "World 1": world =  "world1"; break;
            case "World 2": world =  "world2"; break;
            case "World 3": world =  "world3"; break;
            case "World 4": world =  "world4"; break;
            case "Easy": mode = "easy"; break;
            case "Medium": mode = "mid"; break;
            case "Hard": mode = "hard"; break;
        }
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] 
    public class HighscoreEntry {
        public int score;
        public string name;
    }
}
