using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Scripts")]
    public BallScript ballScript;
    
    [Header("Other Objects")]
    public BallScript ball;
    public BallScript blBall;
    public Paddle playerPaddle;
    public Paddle computerPaddle;

    [Header("Score")]
    private int playerScore;
    private int computerScore;

    [Header("Audio")]
    public AudioSource playerPlusOne;
    public AudioSource computerPlusOne;
    public AudioSource BgMusicStageOne;

    [Header("Text")]
    public TMPro.TMP_Text playerScoreText;
    public TMPro.TMP_Text computerScoreText;

    [Header("Togolable")]
    public GameObject ppVolume;
    public GameObject upUI;
    public GameObject downUI;
    public GameObject smallPP;
    public GameObject mirroredSPP;
    public GameObject playerP;
    public GameObject computerP;
    public GameObject NeonPP;
    public GameObject NeonCP;
    public GameObject balls;
    public GameObject bBall;
    

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        TimedVisualEvents();
        TimedAudioEvents();
    }

    public void PlayerScore()
    {
        playerScore++;
        Debug.Log(playerScore);
        playerScoreText.text = playerScore.ToString();
        ResetRound();
        playerPlusOne.Play();


    }

    public void ComputerScore()
    {
        computerScore++;
        Debug.Log(computerScore);
        computerScoreText.text = computerScore.ToString();
        ResetRound();
        computerPlusOne.Play();
    }

    private void ResetRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.StartingForce();
        blBall.ResetPosition();
        blBall.StartingForce();
    }

    public void TimedVisualEvents()
    {
        if (playerScore == 1)
        {
            ppVolume.SetActive(true);
            upUI.SetActive(false);
            downUI.SetActive(false); 
            balls.SetActive(false);
            bBall.SetActive(true);
            

        }
        if (playerScore == 2)
        {
            smallPP.SetActive(true);
            mirroredSPP.SetActive(true);
            playerP.SetActive(false);
            ballScript.speed = 400.0f;
        }
        if (playerScore == 3)
        {
            smallPP.SetActive(false);
            mirroredSPP.SetActive(false);
            computerP.SetActive(false);
            NeonCP.SetActive(true);
            NeonPP.SetActive(true);
            
            
        }
    }

    public void TimedAudioEvents()
    {
        if (playerScore == 0)
        {
            BgMusicStageOne.Play();
        }
    }
}
   

