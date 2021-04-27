﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    public GameObject particlesystem;
    public GameObject[] gameObjectArray, TreeArray, TreeStumpArray, BlockadeArray;
    public Renderer rend;
    public Collider2D collide;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectArray = GameObject.FindGameObjectsWithTag("Box");
        TreeArray = GameObject.FindGameObjectsWithTag("Tree");
        TreeStumpArray = GameObject.FindGameObjectsWithTag("TreeStump");
        BlockadeArray = GameObject.FindGameObjectsWithTag("Blockade");

        /*foreach (GameObject go in gameObjectArray)
        {
            rend = go.GetComponent<Renderer>();
            rend.enabled = false;
            collide = go.GetComponent<Collider2D>();
            collide.enabled = false;

        }*/


    }

    void Update()
    {
        if (Pickup.count == 4)
        {
            foreach (GameObject blockade in BlockadeArray)
            {
                blockade.SetActive(false);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameManager.ChupaLevelBeaten != true)
        {
            particlesystem.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Player") == true)
        {
            foreach (GameObject tree in TreeArray)
            {
                tree.SetActive(false);
            }
            foreach (GameObject treestump in TreeStumpArray)
            {
                treestump.SetActive(true);
            }

        }
        
     

    }

  

}
