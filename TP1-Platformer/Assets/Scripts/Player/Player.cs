using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private PointBar pointBar;

    private PlayerHealth playerHealth;
    private AudioSource damageSound;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        damageSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12) //water
        {
            TakeDamage(3);
        }
    }

    public void Heal(int points)
    {
        playerHealth.Heal(points);
    }

    public bool IsAlive()
    {
        return playerHealth.isAlive();
    }

    public void TakeDamage(int dmg)
    {
        playerHealth.TakeDamage(dmg);
        damageSound.Play();
        LoseScore(20);
    }

    public void AddScore(int scoreToHad)
    {
        score += scoreToHad;
        pointBar.UpdateScore(score);
    }

    public void LoseScore(int scoreToLose)
    {
        score -= scoreToLose;
        if (score < 0) {
            score = 0;
        }
        pointBar.UpdateScore(score);
    }
}
