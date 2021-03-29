using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTumbleWeed : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("TumbleWeed"))
        {
            Debug.Log("Got tumble");
            Destroy(collision.gameObject);
        }
    }
    
}
