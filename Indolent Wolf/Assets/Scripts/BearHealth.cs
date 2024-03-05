using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearHealth : MonoBehaviour
{
    public int BHealth;
    public Text BearH;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BearH.text = "Bear: " + BHealth;
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Wolf")
        {
            //Output the message
            Debug.Log("Hit With Player");
            BHealth--;
        }
        if (col.collider.tag == "WFangs")
        {
            //Output the message
            Debug.Log("Hit by fangs");
            BHealth =- 5;
        }
    }
}
