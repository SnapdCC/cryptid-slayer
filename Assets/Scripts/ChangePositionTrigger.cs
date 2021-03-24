using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionTrigger : MonoBehaviour
{
    public static bool activatetrigger;
    public GameObject spawnman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("bullet"))
        {
            spawnman.GetComponent<SpawnManager>().SpawnObject();
        }

    }
}
