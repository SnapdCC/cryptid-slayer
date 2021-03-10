using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rbMove;
    public Rigidbody2D rbRotate;
    public Animator animator;
    public Camera cam;

    public SpriteRenderer playersprite;

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

        
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A))
        {
            //moveSpeed += 5;
        }
        if (Input.GetKey(KeyCode.W) == true)
        {
            animator.SetBool("WalkingB", true);
        }
        else
            animator.SetBool("WalkingB", false);

        if (Input.GetKey(KeyCode.A) == true)
        {
            animator.SetBool("WalkingLR", true);
            playersprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) != true)
        {
            animator.SetBool("WalkingLR", false);
            playersprite.flipX = false;
        }
            

        if (Input.GetKey(KeyCode.D) == true)
        {
            animator.SetBool("WalkingLR", true);
        }
        else if (Input.GetKey(KeyCode.A) != true)
            animator.SetBool("WalkingLR", false);

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
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rbMove.MovePosition(rbMove.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 mousedir = mousepos - rbRotate.position;
        float angle = Mathf.Atan2(mousedir.y, mousedir.x) * Mathf.Rad2Deg - 90f;
        // rbRotate.rotation = angle;
    }
}
