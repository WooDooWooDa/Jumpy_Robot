using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect();
        Destroy(this.gameObject, 0.5f);
    }

    private void Collect()
    {
        animator.SetTrigger("Taken");
        audioSource.Play();
        Player.Instance.AddScore(20);
        
    }
}
