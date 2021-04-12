using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMod = 1.5f;
    public SpriteRenderer playersprite;

    public Rigidbody2D rbMove;
    public Rigidbody2D rbRotate;
    public Animator animator;
    public Camera cam;
    public bool sprinting = false;

    bool canSprint;
    bool canSee;

    GameObject[] List;
    SpriteRenderer trap;
    [SerializeField]
    GameObject panel;

    Vector2 movement;
    Vector2 mousepos;
    GameManager GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        canSprint = GameManager.JackIsBeat();
        canSee = GameManager.ChupIsBeat();
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
        {
            animator.SetBool("WalkingB", false);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            animator.SetBool("WalkingLR", true);
            playersprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            animator.SetBool("WalkingLR", true);
            playersprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            animator.SetBool("WalkingLR", false);
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            animator.SetBool("WalkingF", true);
        }
        else
        {
            animator.SetBool("WalkingF", false);
        }
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);


        List = GameObject.FindGameObjectsWithTag("InvisTrap");

        if (Input.GetButtonDown("Fire3")&&canSee)
        {
            panel.SetActive(true);
                foreach (GameObject item in List)
            {
                trap = item.GetComponent<SpriteRenderer>();
                trap.enabled = true;
            }
        }
        else if(Input.GetButtonUp("Fire3")&&canSee)
        {
            panel.SetActive(false);
            foreach (GameObject item in List)
            {
                trap = item.GetComponent<SpriteRenderer>();
                trap.enabled = false;
            }
        }
    }

    void FixedUpdate()
    {
        if(!sprinting){
            rbMove.MovePosition(rbMove.position + movement * moveSpeed * Time.fixedDeltaTime);
        }else if(sprinting&&canSprint){
            rbMove.MovePosition(rbMove.position + movement * (moveSpeed * sprintMod) * Time.fixedDeltaTime);
        }
    }
}