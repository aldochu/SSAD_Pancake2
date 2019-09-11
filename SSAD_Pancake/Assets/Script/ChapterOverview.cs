using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ChapterOverview : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    //Loads new scene
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //goes back to chapter overview
    public void goBackToMenu()
    {
        // TODO: Load UITeacherMenu SceneManager.LoadScene();
    }
}
