using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    bool paused; //controls pause state

    bool gameOn; //represents if player should be pressing spacebar to win

    int curSpaceCounter; //shows how many spacebar hits the player currently has
    //int goalSpaceCounter; //how many spacebar hits the player needs to reach to win
    float countdownTimer; //the amount of time the player has to win before losing

    //bool gameWin; //if the player has won the game
    //bool gameFinish; //if the timer or spacebar count has been finished

    bool gameStart; //if the countdown for the game to begin should be happening
    float gameStartTimer; //how many seconds the player has before the game begins

    bool controls; //menu for the controls

    public Text countText;
    public Text timerText;

    public CountdownManager cdm;

    public CountdownAudioManager cdam;

    public int soundController = 0;

	// Use this for initialization
	void Start () {
        paused = false;

        gameOn = false;

        countdownTimer = 10.0f; //total time for player to play
        curSpaceCounter = 0;
        //goalSpaceCounter = 100;

        //gameWin = false;
        //gameFinish = false;

        gameStart = true;
        gameStartTimer = 3.5f;

        SetCountText();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (gameOn)
        {
            countdownTimer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                curSpaceCounter += 1;
            }
        }
        if (countdownTimer <= 0.0f)
        {
            countdownTimer = 0.0f;
            gameOn = false;
            //gameFinish = true;
        }

        if (gameStart)
        {
            if (!cdm.gameObject.activeSelf)
                cdm.gameObject.SetActive(true);

            if (gameStartTimer >= 2.5f)
            {
                if (!cdm.countdown[0].activeSelf)
                {
                    cdm.countdown[0].SetActive(true);
                    cdm.countdown[1].SetActive(false);
                    cdm.countdown[2].SetActive(false);
                    cdm.countdown[3].SetActive(false);
                }
                if (soundController == 0)
                {
                    print("sound 1");
                    cdam.playNumber();
                    soundController = 1;
                }
            }
            else if (gameStartTimer >= 1.5f)
            {
                if (!cdm.countdown[1].activeSelf)
                {
                    cdm.countdown[1].SetActive(true);
                    cdm.countdown[0].SetActive(false);
                    cdm.countdown[2].SetActive(false);
                    cdm.countdown[3].SetActive(false);
                }
                if (soundController == 1)
                {
                    print("sound 2");
                    cdam.playNumber();
                    soundController = 2;
                }
            }
            else if (gameStartTimer >= 0.5f)
            {
                if (!cdm.countdown[2].activeSelf)
                {
                    cdm.countdown[2].SetActive(true);
                    cdm.countdown[1].SetActive(false);
                    cdm.countdown[0].SetActive(false);
                    cdm.countdown[3].SetActive(false);
                }
                if (soundController == 2)
                {
                    print("sound 3");
                    cdam.playNumber();
                    soundController = 3;
                }
            }
            else if (gameStartTimer >= 0.0f)
            {
                gameOn = true;
                if (!cdm.countdown[3].activeSelf)
                {
                    cdm.countdown[3].SetActive(true);
                    cdm.countdown[1].SetActive(false);
                    cdm.countdown[2].SetActive(false);
                    cdm.countdown[0].SetActive(false);
                }
                if (soundController == 3)
                {
                    print("sound 4");
                    cdam.playGo();
                    soundController = 4;
                }
            }
            else
            {
                cdm.countdown[0].SetActive(false);
                cdm.countdown[1].SetActive(false);
                cdm.countdown[2].SetActive(false);
                cdm.countdown[3].SetActive(false);
                gameStart = false;
            }

            //print(gameStartTimer);
            gameStartTimer -= Time.deltaTime;
        }
        SetCountText();
	}

    private float roundTenth(float number)
    {
        float temp = number;
        return((Mathf.Round(temp * 10.0f)) /10 );
    }

    void SetCountText()
    {
        countText.text = "Bricks Left: " + curSpaceCounter.ToString();
        timerText.text = "Time: " + roundTenth(countdownTimer).ToString();
    }
}
