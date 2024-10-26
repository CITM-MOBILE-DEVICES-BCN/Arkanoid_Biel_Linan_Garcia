using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    

    [SerializeField] private Color hit1Color;
    [SerializeField] private Color hit2Color;
    [SerializeField] private int hitsRemaining = 3;
    
    // Reference to the SpriteRenderer component
    public SpriteRenderer spriteRenderer;

     
   


    void Start()
    {
        
        if (hitsRemaining == 2)
        {
            spriteRenderer.color = hit1Color;  // First hit color change
        }
        else if (hitsRemaining == 1)
        {
            spriteRenderer.color = hit2Color;  // Second hit color change
        }
        
    }

    // This method is called when the block is hit
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Decrease the hit count
        hitsRemaining--;

        if (hitsRemaining == 2)
        {
            GameManager.Instance.AddHitScore();          
            spriteRenderer.color = hit1Color;  // First hit color change
        }
        else if (hitsRemaining == 1)
        {
            GameManager.Instance.AddHitScore();
            spriteRenderer.color = hit2Color;  // Second hit color change
        }
        else if (hitsRemaining <= 0)
        {
            GameManager.Instance.BlockDestroyed();
            Destroy(gameObject);
            
        }
    }
}
