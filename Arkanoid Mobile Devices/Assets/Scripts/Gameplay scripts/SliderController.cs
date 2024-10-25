using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;           // Reference to the UI Slider
    public GameObject objectToMove; // Reference to the GameObject you want to move
    public float movementRange = 10f; // Range of movement for the object

    private Vector3 initialPosition; // Store the initial position of the object

    void Start()
    {
        
        // Capture the object's initial position
        initialPosition = objectToMove.transform.position;

        // Map the object's current position to a value between 0 and 1 for the slider
        slider.value = CalculateSliderValueFromPosition(initialPosition);

        // Move the object based on the initial slider value
        OnSliderValueChanged(slider.value);

        // Subscribe to slider value change event
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    // This method is called whenever the slider's value is changed
    void OnSliderValueChanged(float value)
    {
        // Calculate the new position based on the slider value and movement range
        Vector3 newPosition = initialPosition + new Vector3((value - 0.5f) * movementRange, 0f, 0f);

        // Move the object to the new position
        objectToMove.transform.position = newPosition;
    }

    // Calculate the slider value from the object's initial position
    private float CalculateSliderValueFromPosition(Vector3 position)
    {
        // Normalize the object's position between the movement range
        float offset = position.x - initialPosition.x;
        float normalizedValue = Mathf.Clamp01(0.5f + (offset / movementRange));

        return normalizedValue;
    }
}

    

