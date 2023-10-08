using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        ResetPosition();
        StartingForce();
        rb = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        rb.position = Vector3.zero;
        rb.velocity = Vector3.zero;

       
    }

    public void StartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        rb.AddForce(direction * speed);
        
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }


}
