using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WolfStamina : MonoBehaviour
{
    public Slider staminaSlider; // Assign the stamina slider in the Inspector
    public GameObject blackoutImage; // Assign the blackout image in the Inspector
    public float staminaDecreaseRate = 0.7f; // Time interval for stamina decrease
    public float staminaDecreaseAmount = 5f; // Amount of stamina decrease per interval
    public float staminaRecoveryRate = 0.1f; // Time interval for stamina recovery
    public float staminaRecoveryAmount = 5f; // Amount of stamina recovery per interval
    private float nextStaminaDecrease = 0f; // Timer for next stamina decrease
    private float nextStaminaRecovery = 0f; // Timer for next stamina recovery
    private bool isSleeping = false; // Check if player is in sleep mode
    private bool isInRestArea = false; // Check if player is in the rest area

    void Start()
    {
        // Set the max and current stamina to full
        staminaSlider.maxValue = 100f;
        staminaSlider.value = 100f;
        blackoutImage.SetActive(false); // Make sure blackout screen is invisible at start
    }

    void Update()
    {
        // Check if the forward movement key is held down
        if (Input.GetKey(KeyCode.W) && !isSleeping)
        {
            // Decrease stamina at intervals while moving
            if (Time.time >= nextStaminaDecrease)
            {
                staminaSlider.value -= staminaDecreaseAmount;
                nextStaminaDecrease = Time.time + staminaDecreaseRate;
            }
        }
        // Start sleeping if "S" is pressed, and player is in rest area
        else if (Input.GetKeyDown(KeyCode.S) && isInRestArea)
        {
            StartCoroutine(SleepRoutine()); // Start the sleep routine with blackout effect
        }
    }

    private IEnumerator SleepRoutine()
    {
        isSleeping = true; // Set sleep state to true
        blackoutImage.SetActive(true); // Set blackout screen to fully visible
        yield return new WaitForSeconds(5); // Wait for 3 seconds to simulate sleep

        blackoutImage.SetActive(false); // Remove blackout screen
        RecoverStamina(); // Begin stamina recovery after blackout
    }

    void RecoverStamina()
    {
        if (isSleeping && staminaSlider.value < staminaSlider.maxValue)
        {
            // Gradually recover stamina while sleeping
            if (Time.time >= nextStaminaRecovery)
            {
                staminaSlider.value += staminaRecoveryAmount;
                nextStaminaRecovery = Time.time + staminaRecoveryRate;
            }
            // Stop sleeping when stamina is full
            if (staminaSlider.value >= staminaSlider.maxValue)
            {
                staminaSlider.value = staminaSlider.maxValue; // Cap stamina to max
                isSleeping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if player entered the rest area
        if (other.CompareTag("Rest"))
        {
            isInRestArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if player exited the rest area
        if (other.CompareTag("Rest"))
        {
            isInRestArea = false;
            isSleeping = false; // Stop sleep if player leaves rest area
        }
    }
}
