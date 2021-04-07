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
