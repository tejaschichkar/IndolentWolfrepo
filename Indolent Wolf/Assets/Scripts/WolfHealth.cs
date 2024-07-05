using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfHealth : MonoBehaviour
{
    public int WHealth;
    public Text WolfH;
    public Animator Wanime;
    public InstructionScript canvas;
    public WolfAnimation wolfanimation;
    private bool hasBeenCalled = false;
    public CharacterMove move;
    public GameObject CheckPoint1;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        CheckPoint1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WolfH.text = "Wolf: " + WHealth;
    }
    public void OnCollisionEnter(Collision col)
    {
        /*if (col.collider.tag == "BFangs")
        {
            Wanime.SetTrigger("Damage");//Output the message
            Debug.Log("Hit With BearFangs");
            WHealth--;
            
        }
        if (col.collider.tag == "Bear")
        {
            //Wanime.SetTrigger("Damage");Output the message
            Debug.Log("Hit With Bear");
            WHealth -= 0;
            
        }*/
        if (col.gameObject.CompareTag("CheckPoint1"))
        {
            Destroy(CheckPoint1, 2f);
        }
        if (col.collider.tag == "Rabbit")
        {
            WHealth += 5;
            wolfanimation.Eat();
            slider.value = WHealth;
        }
        if (WHealth == 30 && !hasBeenCalled)
        {
            canvas.EnableIText();
            hasBeenCalled = true;
            move.Compass.SetActive(true);
            move.Dist.SetActive(true);
            CheckPoint1.SetActive(true);
        }
        if(col.collider.tag == "Rock")
        {
            canvas.EnableLast();
            move.controller.constraints = RigidbodyConstraints.FreezeAll;
            move.Player.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    public void OnSliderChanged(float value)
    {
        WolfH.text = value.ToString();
    }
}
