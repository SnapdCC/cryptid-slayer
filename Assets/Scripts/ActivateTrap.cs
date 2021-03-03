using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    public GameObject particlesystem;
    GameObject[] gameObjectArray;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectArray = GameObject.FindGameObjectsWithTag("Box");

        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
        StartCoroutine(waitCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(true);
            particlesystem.SetActive(true);
        }
    

    }

    IEnumerator waitCoroutine()
    {
        yield return new WaitForSeconds(10000);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerDeath.damagecount += .25f;
        waitCoroutine();
    }
}
