using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class LeaderboardController : MonoBehaviour {

    public Highscores highscores;

    private string world = "world1";
    private string chapter = "chap1";
    private string mode = "hard";
    public CRUDScores dbClass;
    public HighscoreTableTransformer transformer;

    private void Awake() {
        dbClass.getLeaderBoard(world, chapter, mode);
    }

    public void DropdownValueChanged(Dropdown Dropdown) {
        Debug.Log(Dropdown.options[Dropdown.value].text);
        dbClass.getLeaderBoard(world, chapter, mode);
    }

    public void RefreshLeaderBoard(){
        highscores = new Highscores() {
            highscoreEntryList = new List<HighscoreEntry>()
        };
        for (int i = 0; i < 15; i++)
        {
            AddHighscoreEntry(dbClass.OrderedScoreList[i].scores,dbClass.OrderedScoreList[i].name);
            Debug.Log(string.Format("Key = {0}, Value = {1}", dbClass.OrderedScoreList[i].scores,dbClass.OrderedScoreList[i].name));
        }
        transformer.transformTable(highscores);
    }

    public void BackToProfMode()
    {
        Application.LoadLevel("ProfMode");
        
    }

    private void AddHighscoreEntry(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
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

    public class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
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
