﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject invsplayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            player.transform.position = new Vector3(-27, -2.83f, 0);
            //invsplayer.transform.position = new Vector3(-27, -2.83f, -9.613f);
        }

    }
}
