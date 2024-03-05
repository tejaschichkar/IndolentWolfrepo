using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera fogCamera;
    public Transform foggyArea; // The transform representing the center of the foggy area

    private bool isInFoggyArea = false;

    private void Start()
    {
        // Make sure the fog camera is initially disabled
        fogCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check if the player is in the foggy area
        bool isPlayerInFoggyArea = Vector3.Distance(mainCamera.transform.position, foggyArea.position) < 100f;

        // Toggle cameras based on the player's location
        if (isPlayerInFoggyArea && !isInFoggyArea)
        {
            StartCoroutine(EnableFogCamera());
        }
        else if (!isPlayerInFoggyArea && isInFoggyArea)
        {
            StartCoroutine(EnableMainCamera());
        }
    }

    private IEnumerator EnableFogCamera()
    {
        isInFoggyArea = true;

        // Disable main camera and enable fog camera
        mainCamera.gameObject.SetActive(false);
        fogCamera.gameObject.SetActive(true);

        // Set fog settings for the fog camera
        RenderSettings.fog = true;
        RenderSettings.fogColor = HexToColor("#2F655C"); // Adjust fog color as needed
        float targetFogDensity = 0.3f;   // Adjust fog density as needed

        // Smoothly interpolate fog density
        float startFogDensity = RenderSettings.fogDensity;
        float elapsed = 0f;
        float duration = 2f; // Adjust transition duration as needed

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            RenderSettings.fogDensity = Mathf.Lerp(startFogDensity, targetFogDensity, elapsed / duration);
            yield return null;
        }

        RenderSettings.fogDensity = targetFogDensity;
    }

    private IEnumerator EnableMainCamera()
    {
        isInFoggyArea = false;

        // Disable fog camera and enable main camera
        fogCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);

        // Reset fog settings for the main camera
        RenderSettings.fog = false;

        // Smoothly interpolate fog density back to 0
        float targetFogDensity = 0f;
        float startFogDensity = RenderSettings.fogDensity;
        float elapsed = 0f;
        float duration = 2f; // Adjust transition duration as needed

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            RenderSettings.fogDensity = Mathf.Lerp(startFogDensity, targetFogDensity, elapsed / duration);
            yield return null;
        }

        RenderSettings.fogDensity = targetFogDensity;
    }

    // Helper method to convert hexadecimal color code to Unity Color
    private Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }
}
