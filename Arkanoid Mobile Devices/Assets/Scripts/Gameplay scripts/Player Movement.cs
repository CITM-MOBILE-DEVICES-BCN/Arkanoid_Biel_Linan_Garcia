using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform ball;         
    public float followSpeed = 5f; 

    private float initialY;        
    private bool isFollowing = false; 

    void Start()
    {               
        initialY = transform.position.y;
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.B))
        {
            isFollowing = !isFollowing; 
        }

        if (isFollowing)
        {
            Vector2 targetPosition = new Vector2(ball.position.x, initialY);

            transform.position = Vector2.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
