using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : MonoBehaviour
{
    public Animator wAnimator;
    // Start is called before the first frame update
    void Start()
    {
        //wAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wAnimator != null)
        {
            if(Input.GetKey(KeyCode.W))
            {
                Walk();
            }
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Sit();
            }
            if(Input.GetKeyDown(KeyCode.T))
            {
                Tackle();
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                Stomp();
            }
        }
    }
    public void Stomp()
    {
        wAnimator.SetTrigger("Stomp");
    }
    public void Tackle()
    {
        wAnimator.SetTrigger("Tackle");
    }
    public void Walk()
    {
        wAnimator.SetTrigger("Walk");
    }
    public void Sit()
    {
        wAnimator.SetTrigger("Sit");
    }
    public void Damage()
    {
        wAnimator.SetTrigger("Damage");
    }
    public void Breath()
    {
        wAnimator.SetTrigger("Breath");
    }
}
    