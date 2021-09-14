using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private HealthBar healthBar;

    private ParticleSystem deathParticleSystem;
    private int currentHealth;
    private bool alive = true;

    void Start()
    {
        deathParticleSystem = GetComponent<ParticleSystem>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public bool isAlive()
    {
        return alive;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            alive = false;
        }
        UpdateHealthBar();
    }

    public void Heal(int point)
    {
        currentHealth += point;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.SetHealth(currentHealth);
    }
}
