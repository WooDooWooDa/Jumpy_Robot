using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpHeight = 8;
    [SerializeField] private float rayDistance = 10;
    [SerializeField] private LayerMask ladderLayer;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isGrounded;
    private bool isClimbing;

    private float inputHorizontal;
    private float inputVertical;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckClimbing();
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        if (inputHorizontal != 0) {
            isClimbing = false;
        }

        body.velocity = new Vector2(inputHorizontal * speed, body.velocity.y);

        if (!isGrounded) {
            transform.Rotate(new Vector3(0, 0, -inputHorizontal / 5));
        }

        if ((Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0.1) && isGrounded) {
            Jump();
        }
        
        if (inputHorizontal > 0.01f || inputHorizontal == 0) {
            spriteRenderer.flipX = false;
        } else if (inputHorizontal < 0.01f) {
            spriteRenderer.flipX = true;
        }

        animator.SetBool("isMoving", inputHorizontal != 0);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        animator.SetTrigger("jump");
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) {
            isGrounded = true;
            isClimbing = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //permet de pas pouvoir sauter en etant en train de tomber dans le vide. might be a feature
    {
        if (collision.gameObject.layer == 7) {
            isGrounded = false;
        }
    }

    private void CheckClimbing()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, rayDistance, ladderLayer);
        if (hitInfo.collider != null) {
            if (Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0.1) {
                isClimbing = true;
            }
        } else {
            isClimbing = false;
        }
        if (isClimbing) {
            inputVertical = Input.GetAxis("Vertical");
            body.velocity = new Vector2(0, inputVertical * speed);
            body.gravityScale = 0;
        } else {
            body.gravityScale = 1;
        }
    }
}
