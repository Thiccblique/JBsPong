using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;
    public Rigidbody2D bBall;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ball.velocity.x > 0.0f)
        {
            if(ball.position.y > transform.position.y)
            {
                rb.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < transform.position.y)
            {
                rb.AddForce(Vector2.down * speed);
            }

        }
        if (bBall.velocity.x > 0.0f)
        {
            if (bBall.position.y > transform.position.y)
            {
                rb.AddForce(Vector2.up * speed);
            }
            else if (bBall.position.y < transform.position.y)
            {
                rb.AddForce(Vector2.down * speed);
            }

        }
        else
        {
            if(transform.position.y > 0.0f)
            {
                rb.AddForce(Vector2.down * speed);
            }
            else if(transform.position.y > 0.0f)
            {
                rb.AddForce(Vector2.up * speed);
            }
        }
    }
}
