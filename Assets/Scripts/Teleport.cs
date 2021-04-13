using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer badtile;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player && this.gameObject.tag != "ChupReturn")
        {
            player.transform.position = new Vector3(-27, -2.83f, 0);
            //invsplayer.transform.position = new Vector3(-27, -2.83f, -9.613f);
            badtile.enabled = true;
        }
        if (collision.gameObject == player && this.gameObject.tag == "ChupReturn")
        {
            player.transform.position = new Vector3(1.175f, -1.157f, 0);
            //invsplayer.transform.position = new Vector3(-27, -2.83f, -9.613f);
            badtile.enabled = true;
        }

    }
}
