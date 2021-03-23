using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportJackL : MonoBehaviour
{
    public GameObject player;
    public int count = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && count == 1)
        {
            player.transform.position = new Vector3(39.61f, -2.42f, 0);
            count = 0;
            //invsplayer.transform.position = new Vector3(-27, -2.83f, -9.613f);

        }
        /*if (collision.gameObject == player && count == 0)
        {
            player.transform.position = new Vector3(4.55f, -3.66f, 0);
            count = 1;
            //invsplayer.transform.position = new Vector3(-27, -2.83f, -9.613f);

        }*/


    }
}
