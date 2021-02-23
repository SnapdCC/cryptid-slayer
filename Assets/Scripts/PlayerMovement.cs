using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;

    Vector2 movement;
    Vector2 mousepos;

    void Start()
    {
        animator.SetBool("WalkingF", false);
        animator.SetBool("WalkingB", false);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

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
        {
            animator.SetBool("WalkingF", false);
        }
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 mousedir = mousepos - rb.position;
        float angle = Mathf.Atan2(mousedir.y, mousedir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
