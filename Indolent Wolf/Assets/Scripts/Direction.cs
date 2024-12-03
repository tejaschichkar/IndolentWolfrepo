using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direction : MonoBehaviour
{
    public Transform[] targets;
    public Camera mainCamera;
    public Text distanceText;
    public Text targetReachedText; // New Text field for reached target name
    public Image arrowImage;

    private int currentTargetIndex = 0;
    private Coroutine hideTextCoroutine;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (arrowImage == null)
        {
            Debug.LogError("Arrow image not assigned!");
        }

        if (targetReachedText != null)
        {
            targetReachedText.text = ""; // Clear text at start
        }
    }

    void Update()
    {
        if (targets == null || targets.Length == 0 || mainCamera == null || distanceText == null || arrowImage == null)
        {
            Debug.LogWarning("Targets, camera, distanceText, or arrowImage not assigned.");
            return;
        }

        // Get the current target
        Transform currentTarget = targets[currentTargetIndex];

        // Calculate the distance to the current target
        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

        // Display the distance on the UI Text
        distanceText.text = $"Distance\n To next place:\n {distanceToTarget:F2}";

        // Check if the player is close to the current target
        if (distanceToTarget < 0.9f)
        {
            // Display the target's name on screen
            if (targetReachedText != null)
            {
                targetReachedText.text = $"Reached: {currentTarget.name}";

                // Stop any ongoing coroutine and start a new one to hide the text
                if (hideTextCoroutine != null)
                {
                    StopCoroutine(hideTextCoroutine);
                }
                hideTextCoroutine = StartCoroutine(HideReachedText());
            }

            // Update to the next target
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }

        // Rotate the arrow image on the Canvas UI
        RotateArrowTowardsTarget(currentTarget.position);
    }

    void RotateArrowTowardsTarget(Vector3 targetPosition)
    {
        // Calculate the direction from the arrow to the target
        Vector3 dirToTarget = targetPosition - transform.position;

        // Project the direction onto the camera's forward axis
        Vector3 dirInCameraSpace = mainCamera.transform.InverseTransformDirection(dirToTarget);

        // Calculate the angle in camera space
        float angle = Mathf.Atan2(dirInCameraSpace.y, dirInCameraSpace.x) * Mathf.Rad2Deg;

        // Rotate the arrow image on the UI Canvas
        arrowImage.rectTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    IEnumerator HideReachedText()
    {
        // Wait for 7 seconds
        yield return new WaitForSeconds(7f);

        // Clear the reached target text
        if (targetReachedText != null)
        {
            targetReachedText.text = "";
        }
    }

    public void ChangeTarget()
    {
        // Get the current target
        Transform currentTarget = targets[currentTargetIndex];

        // Calculate the distance to the current target
        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

        // Display the distance on the UI Text
        distanceText.text = $"Dist: {distanceToTarget:F2}";

        // Check if the player is close to the current target
        if (distanceToTarget < 0.9f)
        {
            // Display the target's name on screen
            if (targetReachedText != null)
            {
                targetReachedText.text = $"Reached: {currentTarget.name}";

                // Stop any ongoing coroutine and start a new one to hide the text
                if (hideTextCoroutine != null)
                {
                    StopCoroutine(hideTextCoroutine);
                }
                hideTextCoroutine = StartCoroutine(HideReachedText());
            }

            // Update to the next target
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }
    }
}