using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    public string platformTag = "Platform";  

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(platformTag))
        {
            Destroy(gameObject);
        }
    }
}
