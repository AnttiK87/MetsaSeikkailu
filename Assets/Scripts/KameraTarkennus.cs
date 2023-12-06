using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTarkennus : MonoBehaviour
{
    public List<GameObject> targetObjects;
    public float rotationSpeed = 1f;
    public float inactivityDuration = 5f; // Adjust the duration of inactivity before disabling
    public float movementThreshold = 0.1f; // Adjust the movement threshold
    public float delayAfterStop = 1f; // Adjust the delay after the object stops moving

    private float inactivityTimer = 0f;
    private Dictionary<GameObject, Vector3> previousPositions = new Dictionary<GameObject, Vector3>();
    private bool isMoving = false;
    private Coroutine delayCoroutine;

    void Start()
    {
        if (targetObjects == null || targetObjects.Count == 0)
        {
            Debug.LogError("Target objects list is not assigned or is empty!");
            enabled = false; // Disable the script if the target objects list is not assigned or is empty
            return;
        }

        // Initialize previous positions for all target objects
        foreach (GameObject targetObject in targetObjects)
        {
            if (targetObject != null)
            {
                previousPositions[targetObject] = targetObject.transform.position;
            }
        }
    }

    void Update()
    {
        // Check if any target objects have moved
        if (HasMoved())
        {
            // Calculate the center point of all moving target objects
            Vector3 centerPoint = CalculateCenterPoint();

            // Calculate the direction from the camera to the center point
            Vector3 directionToCenter = centerPoint - transform.position;

            // Calculate the rotation to look at the center point
            Quaternion targetRotation = Quaternion.LookRotation(directionToCenter);

            // Smoothly interpolate the camera's rotation towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Reset the inactivity timer since there are moving target objects
            inactivityTimer = 0f;
            isMoving = true;

            // If a coroutine is running, stop it
            if (delayCoroutine != null)
            {
                StopCoroutine(delayCoroutine);
            }
        }
        else if (isMoving)
        {
            // No moving target objects, start the delay coroutine
            if (delayCoroutine == null)
            {
                delayCoroutine = StartCoroutine(DelayCoroutine());
            }
        }
        else
        {
            // No moving target objects and delay has passed, start the inactivity timer
            inactivityTimer += Time.deltaTime;

            // Check if the inactivity duration has passed
            if (inactivityTimer >= inactivityDuration)
            {
                // If the duration has passed, disable the script
                enabled = false;
            }
        }
    }

    bool HasMoved()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            if (targetObject != null)
            {
                // Check if the target object has moved beyond the threshold
                float distance = Vector3.Distance(targetObject.transform.position, previousPositions[targetObject]);
                if (distance > movementThreshold)
                {
                    return true;
                }

                // Update the previous position for the next frame
                previousPositions[targetObject] = targetObject.transform.position;
            }
        }
        return false;
    }

    Vector3 CalculateCenterPoint()
    {
        Vector3 centerPoint = Vector3.zero;
        int movingTargets = 0;

        foreach (GameObject targetObject in targetObjects)
        {
            if (targetObject != null)
            {
                // Check if the target object has moved beyond the threshold
                float distance = Vector3.Distance(targetObject.transform.position, previousPositions[targetObject]);
                if (distance > movementThreshold)
                {
                    centerPoint += targetObject.transform.position;
                    movingTargets++;
                }

                // Update the previous position for the next frame
                previousPositions[targetObject] = targetObject.transform.position;
            }
        }

        if (movingTargets > 0)
        {
            centerPoint /= movingTargets;
        }

        return centerPoint;
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(delayAfterStop);
        isMoving = false;
        delayCoroutine = null;
    }
}