using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class DialougesTrigger : MonoBehaviour
{
    public InstructionScript canvas;
    public GameObject Trigger;
    public Transform destination; // Assign the destination object in the Inspector
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    public Animator playerAnimator; // Reference to the player's Animator component
    public PlayableDirector cutsceneDirector;
    public GameObject Elie;
    public GameObject CheckPoint2;

    public bool cutsceneActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Elie.SetActive(false);
        CheckPoint2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canvas.EnableDText();
            canvas.Invoke("EnableEText", 10f);
            cutsceneActive = true;
            StartCoroutine(PlayCutscene());
            Destroy(Trigger, 2);
            Elie.SetActive(true);
            CheckPoint2.SetActive(true);
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
