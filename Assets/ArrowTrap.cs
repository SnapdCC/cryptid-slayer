using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        arrowpoint.SetActive(true);
    }
}
