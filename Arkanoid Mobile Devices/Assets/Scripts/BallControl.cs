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
            Destroy(collision.gameObject);
            ballRb.velocity *= velocityMultiplier;
        }
    }
}
