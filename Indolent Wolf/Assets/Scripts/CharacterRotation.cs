using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public float rotationSpeed = 5.0f; // speed of rotation
    public float minRotation = -360.0f; // minimum rotation angle
    public float maxRotation = 360.0f; // maximum rotation angle

    private float currentRotation = 90.0f; // current rotation angle

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // get horizontal mouse input
        currentRotation += mouseX * rotationSpeed; // add the mouse input to the current rotation
        currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation); // clamp the current rotation angle between the minimum and maximum values

        transform.localRotation = Quaternion.Euler(0.0f, currentRotation, 0.0f); // apply the new rotation to the character's transform
    }
}


