using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootSlashBox : MonoBehaviour
{
    private BigfootFightManager manager;

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
        if (manager.CurrentState == BigfootFightManager.BigfootState.Slashing)
        {
            if(trigger.gameObject.tag == "Player")
            {
                Debug.Log("Ouch");
                manager.PlayerHealth.TakeDamage();
            }
        }
    }

}
