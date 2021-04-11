﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    public GameObject particlesystem;
    GameObject[] gameObjectArray, TreeArray, TreeStumpArray;


    // Start is called before the first frame update
    void Start()
    {
        gameObjectArray = GameObject.FindGameObjectsWithTag("Box");
        TreeArray = GameObject.FindGameObjectsWithTag("Tree");
        TreeStumpArray = GameObject.FindGameObjectsWithTag("TreeStump");

        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(true);
            //particlesystem.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject tree in TreeArray)
            {
                tree.SetActive(false);
            }
            foreach (GameObject treestump in TreeStumpArray)
            {
                treestump.SetActive(true);
            }
            StartCoroutine(waitCoroutine());
        }

    }

    IEnumerator waitCoroutine()
    {
        yield return new WaitForSeconds(1);
        //Debug.Log("I waited!");
        PlayerDeath.damagecount += 1;
        //yield return null;
    }

}
