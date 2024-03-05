using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class CutsceneController : MonoBehaviour
{
    public Transform destination; // Assign the destination object in the Inspector
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    public Animator playerAnimator; // Reference to the player's Animator component
    public PlayableDirector cutsceneDirector;

    public bool cutsceneActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wolf") && !cutsceneActive)
        {
            cutsceneActive = true;
            StartCoroutine(PlayCutscene());
        }
    }

    public IEnumerator PlayCutscene()
    {
        // Play your cutscene here (you can use Unity's Timeline or other methods)
        cutsceneDirector.Play();

        // Wait for the cutscene to finish
        yield return new WaitForSeconds((float)cutsceneDirector.duration);

        // Move the player to the destination
        while (Vector3.Distance(transform.position, destination.position) > 0.1f)
        {
            Vector3 direction = (destination.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            yield return null;
        }

        // Stop the walking animation
        playerAnimator.SetFloat("Speed", 0f);

        // End the cutscene or perform any other necessary actions

        cutsceneActive = false;
    }
}