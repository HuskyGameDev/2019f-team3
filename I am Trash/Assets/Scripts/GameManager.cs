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

    int score = 0;
    public bool canBeatLevel = false;
    public int beatLevelScore = 0;

    public GameObject mainCanvas;
    public Text mainScoreDisplay;
    public GameObject gameOverCanvas;
    public Text gameOverScoreDisplay;

    public Text countdownDisplay;

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
        //gameOverCanvas.SetActive(false);
        //if (canBeatLevel)
        //    beatLevelCanvas.SetActive(false);

        InvokeRepeating("Countdown", 1.0f, 1.0f);
    }

    void Update() {
        switch (gameState) {
            case GameStates.Playing:
                if (levelTimer <= 0.0f) {
                    // update gameState
                    gameState = GameStates.Lose;

                    // set the end game score
                   // gameOverScoreDisplay.text = mainScoreDisplay.text;

                    // switch which GUI is showing
                    //mainCanvas.SetActive(false);
                    //gameOverCanvas.SetActive(true);
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
                //backgroundMusic.volume -= 0.01f;
                /*if (backgroundMusic.volume <= 0.0f) {
                    AudioSource.PlayClipAtPoint(beatLevelSFX, gameObject.transform.position);

                    gameState = GameStates.GameOver;
                }*/
                break;
            case GameStates.GameOver:
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
                break;
        }

    }


    public void Collect(int amount) {
        score += amount;
        if (canBeatLevel) {
            mainScoreDisplay.text = score.ToString() + " of " + beatLevelScore.ToString();
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

