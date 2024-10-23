using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    // Number of hits required to destroy the block
    private int hitsRemaining = 3;

    // Colors to change the block to after each hit (assign these in the Inspector)
    [SerializeField] private Color hit1Color;
    [SerializeField] private Color hit2Color;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component to change the color
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if the SpriteRenderer is correctly assigned
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is missing!");
        }
    }

    // This method is called when the block is hit
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Decrease the hit count
        hitsRemaining--;

        // Change the color based on the number of hits remaining
        if (hitsRemaining == 2)
        {
            spriteRenderer.color = hit1Color;  // First hit color change
        }
        else if (hitsRemaining == 1)
        {
            spriteRenderer.color = hit2Color;  // Second hit color change
        }
        else if (hitsRemaining <= 0)
        {
            // Destroy the block when it reaches 0 hits
            Destroy(gameObject);
        }
    }
}
