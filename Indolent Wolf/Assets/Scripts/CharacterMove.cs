using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 1f; // Base movement speed of the character
    private float maxSpeed = 7f; // Maximum speed limit to prevent spikes
    private float speedIncrement = 0.5f; // Speed increase amount
    public Rigidbody Player;
    public WolfAnimation wolfAnimation;
    public SceneController sceneController;
    public GameObject Compass;
    public GameObject Dist;

    public LayerMask groundLayer; // Layer mask to detect the ground
    private bool isGrounded; // To check if the player is on the ground

    void Start()
    {
        Compass.SetActive(false);
        Dist.SetActive(false);
    }

    void FixedUpdate()
    {
        // Ground check using a Raycast (1.1f distance, you can adjust it)
        isGrounded = Physics.Raycast(Player.transform.position, Vector3.down, 1.1f, groundLayer);

        float vertical = Input.GetAxis("Vertical");

        // Prevent backward movement
        if (vertical < 0)
        {
            vertical = 0;
        }

        // Calculate movement direction and apply speed
        Vector3 movement = new Vector3(0, 0, vertical);
        movement.Normalize(); // Normalize the direction vector
        movement *= speed; // Scale by speed
        movement = transform.TransformDirection(movement); // Apply player rotation

        if (isGrounded)
        {
            // Apply movement to Rigidbody with fixed physics time
            Player.velocity = new Vector3(movement.x, Player.velocity.y, movement.z);
        }
        else
        {
            Player.velocity = new Vector3(movement.x, Mathf.Clamp(Player.velocity.y, -2f, 2f), movement.z);
        }
    }


    void Update()
    {
        // Handle speed increase with key press, clamping to maxSpeed
        if (Input.GetKeyDown(KeyCode.X) && speed + speedIncrement <= maxSpeed)
        {
            speed += speedIncrement;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            speed = Mathf.Min(1f, maxSpeed); // Ensures speed doesn't exceed maxSpeed
        }

        // Pause game functionality
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (sceneController.isPaused)
                sceneController.ResumeGame();
            else
                sceneController.PauseGame();
        }
    }
}
