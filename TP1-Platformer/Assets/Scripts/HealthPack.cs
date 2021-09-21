using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private ParticleSystem healParticle;
    private AudioSource audioSource;
    private int healPoint;

    void Start()
    {
        healPoint = Random.Range(1, 3);
        healParticle = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) {
            HealPlayer();
            Destroy(gameObject, 0.35f);
        }
    }

    private void HealPlayer()
    {
        Player.Instance.Heal(healPoint);
        healParticle.Play();
        audioSource.Play();
    }
}
