using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Other Objects")]
    public Ball ball;
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
    



    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void TimedVisualEvents()
    {
        if (playerScore == 1)
        {
            ppVolume.SetActive(true);
            ;

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
   

