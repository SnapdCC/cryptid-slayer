using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackalopeStopping : MonoBehaviour
{
    public GameObject spawnmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerStay2D(Collider2D trigger)
    {
        Debug.Log("Got caught");
        Debug.Log(trigger.gameObject.tag);
        if (trigger.gameObject.CompareTag("trap"))
        {
            Debug.Log("Does if work");
            trigger.GetComponent<Trap>().Shut();
            spawnmanager.GetComponent<SpawnManager>().enabled = false;
        }
    }
}
