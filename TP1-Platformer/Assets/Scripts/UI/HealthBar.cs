using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    private int maxHealth;

    public void SetHealth(int health)
    {
        healthSlider.value = health;
        healthText.text = "Lives :  " + health + " / " + maxHealth;
    }

    public void SetMaxHealth(int max)
    {
        maxHealth = max;
        healthSlider.maxValue = max;
        SetHealth(max);
    }
}
