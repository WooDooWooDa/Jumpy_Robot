using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private PointBar pointBar;

    private PlayerHealth playerHealth;
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
    }

    public void TakeDamage(int dmg)
    {
        playerHealth.TakeDamage(dmg);
    }

    public void AddScore(int scoreToHad)
    {
        score += scoreToHad;
        pointBar.UpdateScore(score);
    }

    public void LoseScore(int scoreToLose)
    {
        score -= scoreToLose;
        pointBar.UpdateScore(score);
    }
}
