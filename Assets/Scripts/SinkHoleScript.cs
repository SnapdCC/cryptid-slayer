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
            player.transform.position = new Vector3(1.175f, -1.157f, -2.87f);
            PlayerDeath.damagecount++;
            sinkhole.enabled = true;
        }

    }
}
