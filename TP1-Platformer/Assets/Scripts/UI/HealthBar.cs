using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }
}
