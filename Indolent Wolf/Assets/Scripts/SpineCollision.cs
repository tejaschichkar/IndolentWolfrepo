using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpineCollision : MonoBehaviour
{
    public int bHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Fangs")
        {
            //Output the message
            Debug.Log("Hit With Fangs");
            bHealth -= 3;
        }
        if (col.collider.tag == "Head")
        {
            //Output the message
            Debug.Log("Hit With Head");
            bHealth -= 2;
        }
    }
}
