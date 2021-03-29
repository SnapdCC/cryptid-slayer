using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movecam : MonoBehaviour
{
    public Transform endMarker = null;
    public GameObject text;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endMarker.position, Time.deltaTime);
        text.SetActive(true);
    }
}
