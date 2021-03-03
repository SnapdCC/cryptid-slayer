using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    int count;
    int hintcount;
    public GameObject clue1;
    public GameObject clue2;
    public GameObject clue3;
    public GameObject clue4;
    public GameObject hinttext1;
    public GameObject hinttext2;
    public GameObject hinttext3;
    public GameObject border;
    GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 1)
        {
            clue1.SetActive(true);
        }
        if (count == 2)
        {
            clue2.SetActive(true);
        }
        if (count == 3)
        {
            clue3.SetActive(true);
        }
        if (count == 4)
        {
            DestroyAllRocks();
            clue4.SetActive(true);
        }
        if (hintcount == 1)
        {
            hinttext1.SetActive(true);
        }
        if (hintcount == 2)
        {
            hinttext1.SetActive(false);
            hinttext2.SetActive(true);
        }
        if (hintcount == 3)
        {
            hinttext2.SetActive(false);
            hinttext3.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            collision.gameObject.SetActive(false);
            count++;
        }
        if (collision.gameObject.CompareTag("hint"))
        {
            collision.gameObject.SetActive(false);
            hintcount++;
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
