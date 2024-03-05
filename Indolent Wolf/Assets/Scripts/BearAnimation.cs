using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimation : MonoBehaviour
{
    private Animator bAnimator;
    public GameObject player;
    public float speed = 1.5f;
    public float turnRate;
    // Start is called before the first frame update
    void Start()
    {
        bAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = player.transform.position - transform.position;
        transform.LookAt(player.transform.position);
        if(bAnimator != null)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                bAnimator.SetTrigger("SLEEP");
            }
            if(Input.GetKeyDown(KeyCode.O))
            {
                bAnimator.SetTrigger("IDLE");
            }
        }
    }
}
