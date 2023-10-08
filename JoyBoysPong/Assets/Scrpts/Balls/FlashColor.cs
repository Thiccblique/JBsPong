using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{

    public Color flashColor = Color.red;          // The color to flash
    public float flashDuration = 0.2f;           // The duration of each flash
    public int flashCount = 5;                   // The number of times to flash

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private bool isFlashing = false;
    private int flashCounter = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        
    }

    private System.Collections.IEnumerator Flash()
    {
        isFlashing = true;

        while (flashCounter < flashCount)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);

            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);

            flashCounter++;
        }

        flashCounter = 0;
        isFlashing = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Flash());
    }
}

