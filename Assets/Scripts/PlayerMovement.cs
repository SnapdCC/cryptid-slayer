using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Start()
    {
        animator.SetBool("WalkingF", false);
        animator.SetBool("WalkingB", false);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W) == true)
        {
            animator.SetBool("WalkingB", true);
        }
        else
            animator.SetBool("WalkingB", false);
            

        if (Input.GetKey(KeyCode.S) == true)
        {
            animator.SetBool("WalkingF", true);
        }
        else
            animator.SetBool("WalkingF", false);

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
