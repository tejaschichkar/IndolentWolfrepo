using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 5.0f; // speed of the character's movement

    public Rigidbody controller; // reference to the character controller component
    public Rigidbody Player;
    public WolfAnimation wolfAnimation;
    public GameObject Compass;
    public GameObject Dist;

    void Start()
    {
        Compass.SetActive(false);
        Dist.SetActive(false);
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        // Check if the input is negative (backward) and clamp it to zero
        if (vertical < 0)
        {
            vertical = 0;
        }

        Vector3 movement = new Vector3(0, 0, vertical);
        movement.Normalize(); // normalize the direction vector if it is not zero
        movement *= speed * Time.deltaTime; // scale the direction vector by the speed and time
        movement = transform.TransformDirection(movement); // transform the direction vector relative to the character's rotation
        controller.velocity = movement * speed;
        Player.velocity = movement * speed;
        if (Input.GetKeyDown(KeyCode.X))
        {
            speed += 3f;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            speed = 7f;
        }
    }
}

