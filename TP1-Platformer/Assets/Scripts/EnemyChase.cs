using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float rayDistance = 5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    
    private float movingSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, playerLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance, playerLayer);
        if (hitRight.collider != null) {
            MoveTowards(hitRight);
            spriteRenderer.flipX = false;
        } else if (hitLeft.collider != null) {
            MoveTowards(hitLeft);
            spriteRenderer.flipX = true;
        } else {
            animator.SetBool("isMoving", false);
        }
        
    }

    void MoveTowards(RaycastHit2D ray)
    {
        transform.position = Vector3.MoveTowards(transform.position, ray.collider.transform.position, movingSpeed * Time.deltaTime);
        animator.SetBool("isMoving", true); //le animator anime le perso gris
    }
}
