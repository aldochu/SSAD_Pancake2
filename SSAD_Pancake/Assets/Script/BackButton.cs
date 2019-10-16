using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void backMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BackToWorld()
    {
        SceneManager.LoadScene("");
    }
    public void BackToUniverse()
    {
        SceneManager.LoadScene("");
    }


}
