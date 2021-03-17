using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionTrigger : MonoBehaviour
{
    public static bool activatetrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            activatetrigger = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            activatetrigger = false;
        }
    }
}
