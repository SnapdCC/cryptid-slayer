using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    GameObject[] gameObjectArray;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectArray = GameObject.FindGameObjectsWithTag("Box");
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            //Destroy(collision.gameObject);

            health = health - .5f;
        }
    }

}

