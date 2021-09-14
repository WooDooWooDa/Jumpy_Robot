using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public static Computer Instance { get; private set; }

    [SerializeField] private Sprite computerOnSprite;
    private SpriteRenderer spriteRenderer;
    private ParticleSystem onParticleSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        onParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public void TurnOn()
    {
        spriteRenderer.sprite = computerOnSprite;
        onParticleSystem.Play();
    }
}
