using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WolfHealth : MonoBehaviour
{
    public int WHealth;
    public Text WolfH;
    public Animator Wanime;
    public InstructionScript canvas;
    public FogController cFog;
    public WolfAnimation wolfanimation;
    private bool hasBeenCalled = false;
    public CharacterMove move;
    public GameObject CheckPoint1;
    public Slider slider;

    void Start()
    {
        CheckPoint1.SetActive(false);
    }

    void Update()
    {
        WolfH.text = "Wolf: " + WHealth;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("CheckPoint1"))
        {
            Destroy(CheckPoint1, 2f);
        }

        if (col.collider.tag == "Rabbit")
        {
            WHealth += 5;
            slider.value = WHealth;
            StartCoroutine(HandleEating());
        }

        if (WHealth == 30 && !hasBeenCalled)
        {
            canvas.EnableIText();
            hasBeenCalled = true;
            move.Compass.SetActive(true);
            move.Dist.SetActive(true);
            CheckPoint1.SetActive(true);
        }

        if (col.collider.tag == "Rock")
        {
            canvas.EnableLast();
            cFog.SwitchToMainCamera();
            move.Player.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private IEnumerator HandleEating()
    {
        // Stop walking animation and play eating animation
        wolfanimation.StopWalk();
        wolfanimation.Eat();

        // Disable movement while eating
        move.enabled = false;

        // Wait for 3 seconds (duration of the eating animation)
        yield return new WaitForSeconds(3f);

        // Re-enable movement after eating
        move.enabled = true;
    }

    public void OnSliderChanged(float value)
    {
        WolfH.text = value.ToString();
    }
}