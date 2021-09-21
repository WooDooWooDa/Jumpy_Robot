using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private ParticleSystem healParticle;
    private int healPoint;

    void Start()
    {
        healPoint = Random.Range(1, 3);
        healParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) {
            Player.Instance.Heal(healPoint);
            healParticle.Play();
            Destroy(gameObject, 0.35f);
        }
    }

}
