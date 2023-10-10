using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObjectOnApproach : MonoBehaviour
{
    public float freezeDistance = 2.0f; // Distance at which the object freezes
    public float moveSpeed = 5.0f;      // Object's movement speed

    private Transform player;            // Reference to the player's transform
    private bool isFrozen = false;       // Flag to track if the object is frozen

    private Vector3 originalPosition;    // Store the original position of the object

    public GameObject Ball;
    public Transform playerBar;

    void Start()
    {
        // Find the player GameObject by tag (you can also assign it in the Inspector)
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Store the object's original position
        originalPosition = transform.position;
    }

    void Update()
    {
        // Calculate the distance between the object and the player
       

        // Check if the player presses the space key and the object is frozen
        if (isFrozen && Input.GetKeyDown(KeyCode.Space))
        {
            playerBar.DetachChildren();
            Ball.GetComponent<Rigidbody2D>().isKinematic = false;
            Ball.transform.eulerAngles = new Vector3(Ball.transform.position.x, Ball.transform.position.y);
            // Unfreeze the object's movement and continue in its previous direction
            isFrozen = false;
            Vector2 direction = (originalPosition - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
           

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFrozen)
        {
            isFrozen = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Ball.transform.SetParent(playerBar);
            Ball.GetComponent<Rigidbody2D>().isKinematic = true;
            Ball.transform.position = playerBar.transform.position;
            
        }
    }

}
