using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float velocityMultiplier;

    private Rigidbody2D ballRb;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>(); 

        StartCoroutine(StartBallMovement());
    }

    IEnumerator StartBallMovement()
    {
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
}
