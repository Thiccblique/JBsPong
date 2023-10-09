using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anamateing : MonoBehaviour
{
    public float lungeSpeed = 5f;         // Speed of the lunge movement
    public float lungeDistance = 2f;      // Distance to lunge forward
    public float lungeDuration = 1.0f;    // Duration of the lunge
    public float lungeCooldown = 2.0f;    // Cooldown time between lunges

    private Vector3 originalPosition;      // Store the character's original position
    private float lungeTimer = 0f;        // Timer to track the lunge duration
    private bool isLunging = false;        // Flag to track if the character is lunging

    private void Start()
    {
        // Store the character's original position
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (!isLunging)
        {
            // Move the character up and down (change this based on your character's movement)
            // For example, you can use Input.GetKey or other input methods to control the character's vertical movement.
            // Replace this with your actual character movement logic.

            float verticalInput = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(0f, verticalInput * lungeSpeed * Time.deltaTime, 0f);
            transform.Translate(moveDirection);

            // Check if a lunge is triggered (e.g., a button press)
            if (Input.GetKeyDown(KeyCode.Space)) // Replace with your trigger input
            {
                // Trigger the lunge
                StartLunge();
            }
        }
        else
        {
            // Move the character forward during the lunge
            Vector3 lungeDirection = Vector3.right * lungeSpeed * Time.deltaTime;
            transform.Translate(lungeDirection);

            // Update the lunge timer
            lungeTimer += Time.deltaTime;

            // Check if the lunge duration is over
            if (lungeTimer >= lungeDuration)
            {
                // End the lunge
                EndLunge();
            }
        }
    }

    private void StartLunge()
    {
        if (!isLunging)
        {
            // Start the lunge
            isLunging = true;

            // Reset the lunge timer
            lungeTimer = 0f;
        }
    }

    private void EndLunge()
    {
        // End the lunge
        isLunging = false;

        // Move the character back to its original position
        transform.position = originalPosition;

        // Apply a cooldown before the next lunge can be triggered
        StartCoroutine(LungeCooldown());
    }

    private IEnumerator LungeCooldown()
    {
        yield return new WaitForSeconds(lungeCooldown);
    }
}
