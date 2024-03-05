using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElieDialoguesScript : MonoBehaviour
{
    public InstructionScript canvas;
    public CharacterMove move;
    public GameObject Trigger;
    public GameObject CheckPoint2;

    public float freezeDuration = 46.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Wolf"))
        {
            canvas.Invoke("EnableElie1", 1f);
            Destroy(CheckPoint2, 2f);
            Destroy(Trigger, 47f);
            move.Player.constraints = RigidbodyConstraints.FreezeAll;

            StartCoroutine(UnfreezePlayerAfterDelay());
        }
    }

    IEnumerator UnfreezePlayerAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(freezeDuration);

        // Unfreeze the player's constraints
        move.Player.constraints = RigidbodyConstraints.None;

        // You may want to set specific constraints based on your needs
        move.Player.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

    }
}
