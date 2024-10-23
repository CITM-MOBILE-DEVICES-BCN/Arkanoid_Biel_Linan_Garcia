using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;

    private Rigidbody2D ballRb;
    private bool isBallMoving;
    
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBallMoving)
        {
            ballRb.velocity = initialVelocity;
            isBallMoving = true;
        }
    }
}
