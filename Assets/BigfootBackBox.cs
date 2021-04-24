using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootBackBox : MonoBehaviour
{
    BigfootFightManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //initialize manager
        manager = gameObject.GetComponentInParent<BigfootFightManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag.Equals("bullet"))
        {
            manager.BigfootHealth.TakeDamage();
        }
    }
}
