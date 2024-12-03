using UnityEngine;
using UnityEngine.UI;
public class InstructionScript : MonoBehaviour 
{
    public Text canvasText1;
    public Text canvasText2;
    public Text canvasText3;
    public Text canvasText4;
    public Text canvasText5;
    public Text ElieDialogue1;
    public Text BenDialogue1;
    public Text ElieDialogue2;
    public Text BenDialogue2;
    public Text ElieDialogue3;
    public Text Mission1;
    public Text BearDialogue1;
    public Text Last;

    void Start () 
    {
        canvasText1.enabled = false;
        canvasText2.enabled = false;
        canvasText3.enabled = false;
        canvasText4.enabled = false;
        canvasText5.enabled = false;
        ElieDialogue1.enabled = false;
        BenDialogue1.enabled = false;
        ElieDialogue2.enabled = false;
        BenDialogue2.enabled = false;
        ElieDialogue3.enabled = false;
        Mission1.enabled = false;
        BearDialogue1.enabled = false;
        Last.enabled = false;
        Invoke("EnableText", 1f);//invoke after 1 seconds
    }
    void Update ()
    {
        if (canvasText1.enabled == true)
        {
            Invoke("DisableText", 5f);
        }
        if (canvasText2.enabled == true)
        {
            Invoke("DisableBText", 5f);
        }
        if (canvasText3.enabled == true)
        {
            Invoke("DisableIText", 5f);
        }
        if (canvasText4.enabled == true)
        {
            Invoke("DisableDText", 8f);
        }
        if (canvasText5.enabled == true)
        {
            Invoke("DisableEText", 5f);
        }
        Dialouges();
    }
    public void Dialouges()
    {
        if(ElieDialogue1.enabled == true)
        {
            Invoke("DisableElie1", 5f);
            Invoke("EnableBen1", 6f);
        }
        if(BenDialogue1.enabled == true)
        {
            Invoke("DisableBen1", 7f);
            Invoke("EnableElie2", 8f);
        }
        if(ElieDialogue2.enabled == true)
        {
            Invoke("DisableElie2", 7f);
            Invoke("EnableBen2", 8f);
        }
        if(BenDialogue2.enabled == true)
        {
            Invoke("DisableBen2", 7f);
            Invoke("EnableElie3", 8f);
        }
        if(ElieDialogue3.enabled == true)
        {
            Invoke("DisableElie3", 7f);
            Invoke("EnableM1", 8f);
        }
        if(Mission1.enabled == true)
        {
            Invoke("DisableM1", 5f);
        }
        if(BearDialogue1.enabled == true)
        {
            Invoke("DisableBear1", 7f);
        }
    }
    public void EnableText()
    { 
        canvasText1.enabled = true; 
    }
    public void DisableText()
    { 
        canvasText1.enabled = false; 
    }
    public void EnableBText()
    { 
        canvasText2.enabled = true; 
    }
    public void DisableBText()
    { 
        canvasText2.enabled = false; 
    }
    public void EnableIText()
    {
        canvasText3.enabled = true;
    }
    public void DisableIText()
    {
        canvasText3.enabled = false;
    }
    public void EnableDText()
    {
        canvasText4.enabled = true;
    }
    public void DisableDText()
    {
        canvasText4.enabled = false;
    }
    public void EnableEText()
    {
        canvasText5.enabled = true;
    }
    public void DisableEText()
    {
        canvasText5.enabled = false;
    }
    public void EnableElie1()
    {
        ElieDialogue1.enabled = true;
    }
    public void DisableElie1()
    {
        ElieDialogue1.enabled = false;
    }
    public void EnableElie2()
    {
        ElieDialogue2.enabled = true;
    }
    public void DisableElie2()
    {
        ElieDialogue2.enabled = false;
    }
    public void EnableElie3()
    {
        ElieDialogue3.enabled = true;
    }
    public void DisableElie3()
    {
        ElieDialogue3.enabled = false;
    }
    public void EnableM1()
    {
        Mission1.enabled = true;
    }
    public void DisableM1()
    {
        Mission1.enabled = false;
    }
    public void EnableBen1()
    {
        BenDialogue1.enabled = true;
    }
    public void DisableBen1()
    {
        BenDialogue1.enabled = false;
    }
    public void EnableBen2()
    {
        BenDialogue2.enabled = true;
    }
    public void DisableBen2()
    {
        BenDialogue2.enabled = false;
    }
    public void EnableBear1()
    {
        BearDialogue1.enabled = true;
    }
    public void DisableBear1()
    {
        BearDialogue1.enabled = false;
    }
    public void EnableLast()
    {
        Last.enabled = true;
    }
    public void DisableLast()
    {
        Last.enabled = false;
    }
}
