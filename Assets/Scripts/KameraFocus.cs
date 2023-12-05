using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tämän teki ChatGPT
public class KameraFocus : MonoBehaviour
{
    public GameObject targetObject;
    public float rotationSpeed = 1f;
    public float inactivityDuration = 5f; // Adjust the duration of inactivity before disabling

    private float inactivityTimer = 0f;

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            enabled = false; // Disable the script if the target object is not assigned
            return;
        }

    }

    void Update()
    {
        // Check if the target object is active
        if (targetObject != null && targetObject.activeSelf)
        {
            // Calculate the direction from the camera to the target object
            Vector3 directionToTarget = targetObject.transform.position - transform.position;

            // Calculate the rotation to look at the target object
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Smoothly interpolate the camera's rotation towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Target object is not active, start the inactivity timer
            inactivityTimer += Time.deltaTime;

            // Check if the inactivity duration has passed
            if (inactivityTimer >= inactivityDuration)
            {
                // If the duration has passed, disable the script
                enabled = false;
            }
        }

    }
}
