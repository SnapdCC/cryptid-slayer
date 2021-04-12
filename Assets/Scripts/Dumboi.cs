using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumboi : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.position = new Vector3(4.55f, -3.66f, 0);
        }

    }
}
