using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    private int playerScore;
    private int computerScore;

    public TMPro.TMP_Text playerScoreText;
    public TMPro.TMP_Text computerScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerScore()
    {
        playerScore++;
        Debug.Log(playerScore);
        playerScoreText.text = playerScore.ToString();
        ResetRound();


    }

    public void ComputerScore()
    {
        computerScore++;
        Debug.Log(computerScore);
        computerScoreText.text = computerScore.ToString();
        ResetRound();
    }

    private void ResetRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.StartingForce();
    }
    
}
