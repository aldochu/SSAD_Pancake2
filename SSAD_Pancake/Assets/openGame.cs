using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class openGame : MonoBehaviour
{
    public Button volcanoGame;
    public Button goHome;
    public Button caveGame;
    public Button rocketGame;
    public Button castleGame;

    public game mapManager;

    public Text volcano;
    public Text home;
    public Text cave;
    public Text rocket;
    public Text castle;

    public Text world;

    public int turn = 0;
    public int volcano_turn = 0;
    public int rocket_turn = 0;
    public int cave_turn = 0;
    public int castle_turn = 0;
    public int home_turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        volcanoGame.image.alphaHitTestMinimumThreshold = 0.3f;
        goHome.image.alphaHitTestMinimumThreshold = 0.5f;
        caveGame.image.alphaHitTestMinimumThreshold = 0.5f;
        rocketGame.image.alphaHitTestMinimumThreshold = 0.5f;
        castleGame.image.alphaHitTestMinimumThreshold = 0.1f;

        world.text = "CZ2002";

        volcanoGame.onClick.AddListener(() => newVolcanoTurn());
        volcano.text = "Volcano: " + turn;
        goHome.onClick.AddListener(() => newHomeTurn());
        home.text = "Home: " + turn;
        caveGame.onClick.AddListener(() => newCaveTurn());
        cave.text = "Cave: " + turn;
        rocketGame.onClick.AddListener(() => newRocketTurn());
        rocket.text = "Rocket: " + turn;
        castleGame.onClick.AddListener(() => newCastleTurn());
        castle.text = "Castle: " + turn;

        //yield return new WaitUntil(() => callVolcano == true || callRocket == true || callCave == true || callHome == true || callCastle ==true);
       
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    void newVolcanoTurn()
    { 
        volcanoGame.image.alphaHitTestMinimumThreshold = 0.5f;
        volcano_turn++;
        volcano.text = "Volcano: " + volcano_turn;

    }
    void newRocketTurn()
    {
        rocket_turn++;
        rocket.text = "Rocket: " + rocket_turn;
    }
    void newCaveTurn()
    {
        cave_turn++;
        cave.text = "Cave: " + cave_turn;
    }
    void newCastleTurn()
    {
        castleGame.image.alphaHitTestMinimumThreshold = 0.5f;
        castle_turn++;
        castle.text = "Castle: " + castle_turn;
    }
    void newHomeTurn()
    {
        home_turn++;
        home.text = "Home: " + home_turn;
    }
    void newTurn(){
      turn++;
      volcano.text = "Volcano: " + turn;
    }
}
