using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    int count;
    GameObject[] gameObjects;
    public GameObject border;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 4)
        {
            DestroyAllRocks();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            collision.gameObject.SetActive(false);
            count++;
        }
    }

    void DestroyAllRocks()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("rock");

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        Destroy(border);
    }
}
