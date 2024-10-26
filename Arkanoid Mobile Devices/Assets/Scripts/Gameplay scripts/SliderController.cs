using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    public GameObject limitLeft;
    public GameObject limitRight;
    public Slider slider;           
    public GameObject objectToMove; 
    public float movementRange = 10f; 


    private Vector3 initialPosition; 

    void Start()
    {
        
       
    }

    private void Update()
    {
        float newX = Mathf.Lerp(limitLeft.transform.position.x, limitRight.transform.position.x, slider.value);
       objectToMove.transform.position = new Vector3(newX, objectToMove.transform.position.y, objectToMove.transform.position.z);
    }

}

    

