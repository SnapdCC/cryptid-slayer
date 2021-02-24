using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Cryptid"))
        {
            //Destroy(collision.gameObject);

            health = health - .25f;
        }
    }
}
