using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    int stop = 0;
    public static int count, tntcount, trappickupcount, hintcount;
    public GameObject Explosion;
    public GameObject script;
    public GameObject clue1, clue2, clue3, clue4;
    public GameObject hinttext1, hinttext2, hinttext3;
    public GameObject hint1, hint2, hint3;
    public GameObject border;
    public GameObject cam1, cam2;
    public GameObject chestclose, chestopen;
    public GameObject Jackalope;
    public GameObject Traptext;
    GameObject[] gameObjects;
    public GameObject spawnmanager;
    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
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
            //DestroyAllRocks();
            clue4.SetActive(true);
            CamMovement();
            Jackalope.SetActive(true);
        }
        if (hintcount == 1)
        {
            hinttext1.SetActive(true);
            hint1.SetActive(true);
        }
        if (hintcount == 2)
        {
            hinttext1.SetActive(false);
            hinttext2.SetActive(true);
            hint2.SetActive(true);
        }
        if (hintcount == 3)
        {
            hinttext2.SetActive(false);
            hinttext3.SetActive(true);
            hint3.SetActive(true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chest"))
        {
            chestclose.SetActive(false);
            chestopen.SetActive(true);
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
        if (collision.gameObject.CompareTag("tnt"))
        {
            collision.gameObject.SetActive(false);
            tntcount++;
        }
        if (collision.gameObject.CompareTag("trappickup"))
        {
            collision.gameObject.SetActive(false);
            trappickupcount++;
            Traptext.SetActive(true);
            
        }
        if (collision.gameObject.CompareTag("ExplosionTrigger"))
        {
            if (tntcount == 1 && count == 4)
            {
                Explosion.SetActive(true);
                DestroyAllRocks();
            }
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
    void CamMovement()
    {
        
        if (stop == 0)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        cam2.GetComponent<movecam>().enabled = true;
        if(Input.GetKeyDown(KeyCode.Z))
        {
            stop = 1;
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
    }
}
