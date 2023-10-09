using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispendable : MonoBehaviour
{

    public float delayTime = 2f;
    public int currentHealth = 3;
    private int maxHealth = 3;
    private SpriteRenderer spriteRenderer;
    public int blocksDestroyed = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        VisualHealth();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentHealth--;
        if (other.CompareTag("Ball") && currentHealth <= 0)
        {


            Invoke("DestroyObject", delayTime);
            

        }
    }

    private void VisualHealth()
    {
        if (currentHealth == maxHealth)
        {
            spriteRenderer.color = Color.green;
        }
        if (currentHealth == 2)
        {
            spriteRenderer.color = Color.yellow;
        }
        if(currentHealth == 1)
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
