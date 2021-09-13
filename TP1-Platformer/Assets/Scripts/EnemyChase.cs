using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    private Animator animator;
    private Rigidbody2D body;

    private float rayDistance = 5f;
    private float movingSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, playerLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance, playerLayer);
        if (hitRight.collider != null) {
            transform.position = Vector3.MoveTowards(transform.position, hitRight.collider.transform.position, movingSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);       //le animator anime le perso gris
        } else if (hitLeft.collider != null) {
            transform.position = Vector3.MoveTowards(transform.position, hitLeft.collider.transform.position, movingSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        } else
        {
            animator.SetBool("isMoving", false);
        }
        
    }
}
