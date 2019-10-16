using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirectManager : MonoBehaviour
{
    // Start is called before the first frame update
    int game;
    void Start()
    {
        game = 1;
    }

    public void startGame()
    {
        if (game==1)
        {
            SceneManager.LoadScene("Game1");
        }
        else if (game==2)
        {
            SceneManager.LoadScene("Game2");
        }
        else if (game == 3)
        {
            SceneManager.LoadScene("Game3");
        }
        else if (game == 4)
        {
            SceneManager.LoadScene("Game4");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
