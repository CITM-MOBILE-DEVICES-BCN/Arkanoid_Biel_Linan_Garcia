using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float velocityMultiplier;
    public Rigidbody2D ballRigidbody;    
    public Transform platformTransform;  
    public float horizontalForce = 10f;
    public GameManager gameManager;
    public Transform ballSpawnPoint;

    private Rigidbody2D ballRb;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        ballRb = GetComponent<Rigidbody2D>(); 

        StartCoroutine(StartBallMovement());
    }

    IEnumerator StartBallMovement()
    {
        Debug.Log("starballmov");
        yield return new WaitForSeconds(2);

        ballRb.velocity = initialVelocity;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if(collision.gameObject.CompareTag("Block"))
        {
            
            ballRb.velocity *= velocityMultiplier;
           // GameManager.Instance.BlockDestroyed();
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            // Get the contact point between the ball and the platform
            ContactPoint2D contactPoint = collision.GetContact(0);

            // Calculate the relative hit position on the platform
            float platformWidth = collision.collider.bounds.size.x; // Width of the platform
            float hitPosition = contactPoint.point.x - platformTransform.position.x; // Distance from center of platform

            // Normalize hit position to get value between -1 (left) to 1 (right)
            float normalizedHitPosition = (hitPosition / platformWidth) * 2;

            // Apply force based on hit position
            Vector2 ballVelocity = ballRigidbody.velocity;
            ballVelocity.x = normalizedHitPosition * horizontalForce;  // Adjust horizontal velocity
            ballRigidbody.velocity = ballVelocity;

            
        }

        if (collision.gameObject.CompareTag("OutofBounds"))
        {
            if (gameManager.currentLives > 0)
            {
                gameManager.LoseLife();
                RespawnBall();
            }
            else
            {
                // If no lives are left, handle game over (ball destruction or stop game logic)
                Destroy(collision.gameObject);  // Optionally destroy the ball
            }

        }
    }

    private void VelocityFix()
    {
        float velocityDelta = 0.5f;
        float minVelocity = 0.2f;

        if (Mathf.Abs(ballRb.velocity.x) < minVelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(0f, velocityDelta);
        }
    }
    void RespawnBall()
    {
        // Reset the ball's position to the spawn point
        transform.position = ballSpawnPoint.position;

        // Reset the ball's velocity to zero so it doesn't carry momentum
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        StartCoroutine(StartBallMovement());
    }
}
