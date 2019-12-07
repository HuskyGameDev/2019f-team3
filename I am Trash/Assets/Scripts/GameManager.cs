using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    // If not set, the player will default to the gameObject tagged as Player
    public GameObject player;

    enum GameStates { Playing, Lose, GameOver, BeatLevel };
    GameStates gameState = GameStates.Playing;

    public float levelTimer = 30.0f;
    
    public GameObject inventoryCanvas1;
    public GameObject inventoryCanvas2;
    public GameObject inventoryCanvas3;
    public GameObject inventoryCanvas4;

    public int inventory = 0;
    int score = 0;
    
    public bool canBeatLevel = false;
    public int beatLevelScore = 0;

    public GameObject mainCanvas;
    public Text mainScoreDisplay;
    public Text countdownDisplay;
    public GameObject gameOverCanvas;
    public Text gameOverScoreDisplay;

    // Only need to set if canBeatLevel is set to true
    public GameObject beatLevelCanvas;

    //public AudioSource backgroundMusic;
    //public AudioClip gameOverSFX;

    // Only need to set if canBeatLevel is set to true
    //public AudioClip beatLevelSFX;


    void Start() {
        if (gm == null)
            gm = gameObject.GetComponent<GameManager>();
                    
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        mainCanvas.SetActive(true);

        // setup score display
        Collect(0);

        countdownDisplay.text = levelTimer.ToString();

        // make other UI inactive
        gameOverCanvas.SetActive(false);
        inventoryCanvas1.SetActive(false);
        inventoryCanvas2.SetActive(false);
        inventoryCanvas3.SetActive(false);
        inventoryCanvas4.SetActive(false);
        if (canBeatLevel)
            beatLevelCanvas.SetActive(false);

        InvokeRepeating("Countdown", 1.0f, 1.0f);
    }

    void Update() {
        switch (gameState) {
            case GameStates.Playing:
                if (levelTimer <= 0.0f) {
                    // update gameState
                    gameState = GameStates.Lose;

                    // set the end game score
                    gameOverScoreDisplay.text = mainScoreDisplay.text;

                    // switch which GUI is showing
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                else if (canBeatLevel && score >= beatLevelScore) {
                    // update gameState
                    gameState = GameStates.BeatLevel;

                    // hide the player so game doesn't continue playing
                    player.SetActive(false);

                    // switch which GUI is showing
                    mainCanvas.SetActive(false);
                    beatLevelCanvas.SetActive(true);
                }
                break;

           case GameStates.Lose:
                /*backgroundMusic.volume -= 0.01f;
                if (backgroundMusic.volume <= 0.0f) {
                    AudioSource.PlayClipAtPoint(gameOverSFX, gameObject.transform.position);

                    gameState = GameStates.GameOver;
                }*/

                gameState = GameStates.GameOver;
                break;
            case GameStates.BeatLevel:
                /*backgroundMusic.volume -= 0.01f;
                if (backgroundMusic.volume <= 0.0f) {
                    AudioSource.PlayClipAtPoint(beatLevelSFX, gameObject.transform.position);

                    gameState = GameStates.GameOver;
                }*/

                gameState = GameStates.GameOver;
                break;
            case GameStates.GameOver:
                break;
        }

    }
    
    public void updateTrash(int trash)
    {
        inventory = trash;
        switch(inventory) {
            case (0):
                inventoryCanvas1.SetActive(false);
                inventoryCanvas2.SetActive(false);
                inventoryCanvas3.SetActive(false);
                inventoryCanvas4.SetActive(false);
                break;
            case (1): 
                inventoryCanvas1.SetActive(true);
                break;
            case (2): 
                inventoryCanvas2.SetActive(true);
                break;
            case (3): 
                inventoryCanvas3.SetActive(true);
                break;
            case (4): 
                inventoryCanvas4.SetActive(true);
                break;
        }
    }


    public void Collect(int amount) {
        score += amount;
        if (canBeatLevel) {
            mainScoreDisplay.text = score.ToString() + " in Dumpster";
        }
        else {
            mainScoreDisplay.text = score.ToString();
        }
    }

    void Countdown()
    {
        levelTimer -= 1;
        countdownDisplay.text = levelTimer.ToString();
    }
}

