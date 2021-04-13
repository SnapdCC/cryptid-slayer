using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkHoleScript : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer sinkhole;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            //player.transform.position = new Vector3(1.175f, -1.157f, 0);
            player.transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y, player.transform.position.z);
            PlayerDeath.damagecount++;
            sinkhole.enabled = true;
        }

    }
}
