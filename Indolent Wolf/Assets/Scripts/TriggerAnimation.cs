using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator bAnimator;
    public GameObject Bear;
    public InstructionScript canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a specific tag (e.g., "Player")
        if (collision.gameObject.CompareTag("Wolf"))
        {
            if (this.name == "FrontTrigger")
            {
                Debug.Log("Animation Triggered");
                // Trigger the animation when the collision happens
                bAnimator.SetTrigger("IDLE");
                Destroy(gameObject);
                canvas.EnableBText();
            }
            if (this.name == "LeftTrigger")
            {
                Debug.Log("Animation Triggered");
                // Trigger the animation when the collision happens
                bAnimator.SetTrigger("Jump");
                Bear.transform.Rotate(0f, -90f, 0f);
                Destroy(gameObject);
            }
            if (this.name == "RightTrigger")
            {
                Debug.Log("Animation Triggered");
                // Trigger the animation when the collision happens
                bAnimator.SetTrigger("Jump");
                Bear.transform.Rotate(0f, 90f, 0f);
                Destroy(gameObject);
            }
            if (this.name == "BackTrigger")
            {
                Debug.Log("Animation Triggered");
                // Trigger the animation when the collision happens
                bAnimator.SetTrigger("Jump");
                Bear.transform.Rotate(0f, 180f, 0f);
                Destroy(gameObject);
            }
        }
    }
}
