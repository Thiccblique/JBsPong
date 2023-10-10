using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool hasBeenCalled = false;

    [Header("Scripts")]
    public BallScript ballScript;
    public BallScript ball;
    public BallScript blBall;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public Bar playerBar;
    public Bar computerBar;
    public Dispendable dispendable; 
    

    [Header("Score")]
    public int playerScore;
    private int computerScore;
    private int dispendableScore;

    [Header("Audio")]
    public AudioSource playerPlusOne;
    public AudioSource computerPlusOne;
    public AudioSource BgMusicStageOne;
    public AudioSource BgMusicStageTwo;
    

    [Header("Text")]
    public TMPro.TMP_Text playerScoreText;
    public TMPro.TMP_Text computerScoreText;
    public TMPro.TMP_Text breakPlayerScoreText;
    public TMPro.TMP_Text breakComputerScoreText;
    
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
    public GameObject traingball;
    public GameObject bBall;
    public GameObject pong;
    public GameObject breakout;
    public GameObject canvas;
    public GameObject breakCanvas;
    public GameObject bgUI;
    public GameObject firstBlockSet;
    public GameObject secondBlockSet;
    public GameObject thirdBlockSet;
    public GameObject mirroredSPD;
    public GameObject smallPD;
    public GameObject advBar;
    public GameObject pBar;
    public GameObject spaceUI;
    public GameObject talkBackText;
    public GameObject betterWalls;
    public GameObject pongWalls;
    public GameObject breakoutWalls;





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
        BlockCounter();
        //Invoke("DestroyObject", delayTime); 
        RestartCurrentScene();
    }

    public void RestartCurrentScene()
    {
        
        if (computerScore >= 30)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        
    }


    private void ResetRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        playerBar.ResetPosition();
        computerBar.ResetPosition();
        ball.ResetPosition();
        ball.StartingForce();
        blBall.ResetPosition();
        blBall.StartingForce();
    }

    public void TimedVisualEvents()
    {
        if (playerScore <= 1)
        {
            upUI.SetActive(true);
            downUI.SetActive(true);
            traingball.SetActive(true);
        }
        if (playerScore == 2)
        {
            ppVolume.SetActive(true);
            upUI.SetActive(false);
            downUI.SetActive(false); 
            traingball.SetActive(false);
            bBall.SetActive(true);
            talkBackText.SetActive(true);
            

        }
        else if (playerScore == 3)
        {
            smallPP.SetActive(true);
            mirroredSPP.SetActive(true);
            playerP.SetActive(false);
            talkBackText.SetActive(false);
            
        }
        else if (playerScore == 4)
        {
            ballScript.speed = 300.0f;
            smallPP.SetActive(false);
            mirroredSPP.SetActive(false);
            computerP.SetActive(false);
            NeonCP.SetActive(true);
            NeonPP.SetActive(true);
            traingball.SetActive(true);
        }
        else if (playerScore == 5)
        {
            traingball.SetActive(true);
            traingball.SetActive(true);
        } 
        else if (playerScore == 8)
        {
            pong.SetActive(false);
            breakout.SetActive(true);
            traingball.SetActive(false);
            bgUI.SetActive(true);
        }
        else if (playerScore == 9)
        {
            bgUI.SetActive(false);
        } 
        else if (playerScore == 10)
        {
            firstBlockSet.SetActive(true);
        } 
        else if (playerScore == 12)
        {
            pBar.SetActive(false);
            secondBlockSet.SetActive(true);
            firstBlockSet.SetActive(false);
            smallPD.SetActive(true);
            mirroredSPD.SetActive(true);
            
        }
        else if (playerScore == 15)
        {
            secondBlockSet.SetActive(false);
            smallPD.SetActive(false);
            mirroredSPD.SetActive(false);
            thirdBlockSet.SetActive(true);
            advBar.SetActive(true);
            spaceUI.SetActive(true);
          
        }
        else if (playerScore == 19)
        {
            pong.SetActive(true);
            computerPaddle.speed = 17;
            spaceUI.SetActive(false);
            betterWalls.SetActive(true);
            pongWalls.SetActive(false);
            breakoutWalls.SetActive(false);
            
            
        }

    }

    public void TimedAudioEvents()
    {
        if (playerScore == 1)
        {
            BgMusicStageOne.Play();
        }
        if (playerScore == 8)
        {
            BgMusicStageOne.Stop();
            BgMusicStageTwo.Play();

        }
    }


    public void PlayerScore()
    {
        playerScore++;
        Debug.Log(playerScore);
        playerScoreText.text = playerScore.ToString();
        breakPlayerScoreText.text = playerScore.ToString();
        ResetRound();
        playerPlusOne.Play();


    }

    public void ComputerScore()
    {
        computerScore++;
        Debug.Log(computerScore);
        computerScoreText.text = computerScore.ToString();
        breakComputerScoreText.text = computerScore.ToString();
        ResetRound();
        computerPlusOne.Play();
    }

    public void BlockCounter()
    {
        
        if (dispendable.currentHealth <= 0)
        {
            dispendableScore++;
            Debug.Log("Blocks Destroyed = " + (dispendableScore));

        }
    }
}
   

