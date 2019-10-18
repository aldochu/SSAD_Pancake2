using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class worldToUniverseSceneSwitch : MonoBehaviour
{
    
    public void GotoUniverseScene()
    {
        SceneManager.LoadScene("Universe");
    }

    public void GotoWorld1Scene()
    {
        StaticVariable.world = "world1";
        SceneManager.LoadScene("World1");
    }

    public void GotoWorld2Scene()
    {
        StaticVariable.world = "world2";
        SceneManager.LoadScene("World2");
    }

    public void GotoGame1Easy()
    {
        StaticVariable.game = 1;
        StaticVariable.difficulty = "easy";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame1Medium()
    {
        StaticVariable.game = 1;
        StaticVariable.difficulty = "medium";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame1Hard()
    {
        StaticVariable.game = 1;
        StaticVariable.difficulty = "hard";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame2Easy()
    {
        StaticVariable.game = 2;
        StaticVariable.difficulty = "easy";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame2Medium()
    {
        StaticVariable.game = 2;
        StaticVariable.difficulty = "medium";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame2Hard()
    {
        StaticVariable.game = 2;
        StaticVariable.difficulty = "hard";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame3Easy()
    {
        StaticVariable.game = 3;
        StaticVariable.difficulty = "easy";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame3Medium()
    {
        StaticVariable.game = 3;
        StaticVariable.difficulty = "medium";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame3Hard()
    {
        StaticVariable.game = 3;
        StaticVariable.difficulty = "hard";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame4Easy()
    {
        StaticVariable.game = 4;
        StaticVariable.difficulty = "easy";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame4Medium()
    {
        StaticVariable.game = 4;
        StaticVariable.difficulty = "medium";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame4Hard()
    {
        StaticVariable.game = 4;
        StaticVariable.difficulty = "hard";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GoToLeaderBoard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}