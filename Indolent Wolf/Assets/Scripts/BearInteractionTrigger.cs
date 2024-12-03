using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearInteractionTrigger : MonoBehaviour
{
    public Text interactionText;
    public InstructionScript canvas;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger area
        if (other.CompareTag("Player"))
        {
            // Show interaction text
            interactionText.text = "Press L to talk with Bear";
            interactionText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger area
        if (other.CompareTag("Player"))
        {
            // Hide interaction text
            interactionText.enabled = false;
        }
    }

    private void Update()
    {
        // Optional: Check if "P" key is pressed while interacting
        if (interactionText.enabled)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                canvas.Invoke("EnableBear1", 1f);
                interactionText.enabled = false;
            }
        }
    }
}
