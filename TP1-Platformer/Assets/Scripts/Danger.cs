using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private int damage = 1;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Player.Instance.TakeDamage(damage);
            particleSystem.transform.position = collision.gameObject.transform.position;
            particleSystem.Play();
        }
    }

}
