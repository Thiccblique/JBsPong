using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerBar : Bar
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
        if (ball.velocity.y > 0.0f)
        {
            if (ball.position.x > transform.position.x)
            {
                rb.AddForce(Vector2.right * speed);
            }
            else if (ball.position.x < transform.position.x)
            {
                rb.AddForce(Vector2.left * speed);
            }

        }
        if (bBall.velocity.y > 0.0f)
        {
            if (bBall.position.x > transform.position.x)
            {
                rb.AddForce(Vector2.right * speed);
            }
            else if (bBall.position.x < transform.position.x)
            {
                rb.AddForce(Vector2.left * speed);
            }

        }
        else
        {
            if (transform.position.x > 0.0f)
            {
                rb.AddForce(Vector2.left * speed);
            }
            else if (transform.position.x > 0.0f)
            {
                rb.AddForce(Vector2.right * speed);
            }
        }
    }
}
