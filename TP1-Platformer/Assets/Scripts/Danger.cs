using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private ParticleSystem damageParticleSystem;
    private int damage = 1;

    private void Start()
    {
        damageParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Player.Instance.TakeDamage(damage);
            damageParticleSystem.transform.position = collision.gameObject.transform.position;
            damageParticleSystem.Play();
        }
    }

}
