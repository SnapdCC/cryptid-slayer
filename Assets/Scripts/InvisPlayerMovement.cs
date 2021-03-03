using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisPlayerMovement : MonoBehaviour
{
public float moveSpeed = 5f;

    public Rigidbody2D rbMove;
    public Rigidbody2D rbRotate;
    public Rigidbody2D player;
    public Camera cam;
    Vector2 movement;
    Vector2 mousepos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rbMove.MovePosition(rbMove.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 mousedir = mousepos - rbRotate.position;
        float angle = Mathf.Atan2(mousedir.y, mousedir.x) * Mathf.Rad2Deg - 90f;
        rbRotate.rotation = angle;
    }
}
