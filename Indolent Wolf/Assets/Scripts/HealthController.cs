using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public WolfHealth wolfhealth;
    public Slider slider;

    public void OnSliderChanged(float value)
    {
        wolfhealth.WolfH.text = value.ToString();
    }
    public void UpdateProgress()
    {
        slider.value = wolfhealth.WHealth;
    }
}
