using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionOverview : MonoBehaviour
{
    public void Start()
    {
        
    }

    //loads the EditQandA scene
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //goes backt to the chapteroverview scene
    public void goBack()
    {
        SceneManager.LoadScene("ChapterOverview");
    }
}
