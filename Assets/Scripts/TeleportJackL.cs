using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportJackL : MonoBehaviour
{
    public GameObject player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.position = new Vector3(39.61f, -2.42f, 0);
            //invsplayer.transform.position = new Vector3(-27, -2.83f, -9.613f);

        }

    }
}
