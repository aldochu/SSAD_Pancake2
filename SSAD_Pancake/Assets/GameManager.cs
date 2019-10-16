using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startButton;
    public GameObject replayButton;
    public void StartGame()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
        replayButton.SetActive(false);
    }

    public void Replay()
    {
       // SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
