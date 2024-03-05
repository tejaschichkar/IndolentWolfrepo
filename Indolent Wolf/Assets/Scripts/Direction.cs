using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direction : MonoBehaviour
{
    public Transform[] targets;
    public Camera mainCamera;
    public Text distanceText;
    public Image arrowImage;

    private int currentTargetIndex = 0;

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
        distanceText.text = $"Dist: {distanceToTarget:F2}";

        // Check if the player is close to the current target
        if (distanceToTarget < 0.9f)
        {
            // Print a debug message with the target name
            Debug.Log($"Reached target: {currentTarget.name}");

            // Update to the next target
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }

        // Get the target position in world space
        Vector3 targetPosition = currentTarget.position;

        // Calculate the direction from the arrow to the target
        /*Vector3 dirToTarget = targetPos - transform.position;

        // Project the direction onto the camera's forward axis
        Vector3 dirInCameraSpace = mainCamera.transform.InverseTransformDirection(dirToTarget);

        // Calculate the angle in camera space
        float angle = Mathf.Atan2(dirInCameraSpace.y, dirInCameraSpace.x) * Mathf.Rad2Deg;*/

        // Rotate the arrow on the Z-axis
        //transform.rotation = Quaternion.Euler(0f, 0f, angle);

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
            // Print a debug message with the target name
            Debug.Log($"Reached target: {currentTarget.name}");

            // Update to the next target
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }
    }
}
