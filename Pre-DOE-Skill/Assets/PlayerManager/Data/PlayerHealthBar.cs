using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;

    public void Init(float maxHealth,float health)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    public void UpdateHealth(float health)
    {
        slider.value = health;
    }
}
