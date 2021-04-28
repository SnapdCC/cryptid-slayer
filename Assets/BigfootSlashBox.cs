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

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (manager.CurrentState == BigfootFightManager.BigfootState.Slashing)
        {
            if(trigger.gameObject.tag == "Player")
            {
                if(!manager.PlayerWasSlashed)
                {
                    for(int i = 0; i < manager.SlashDamage; i++)
                        manager.PlayerHealth.TakeDamage();
                    manager.PlayerWasSlashed = true;
                }
            }
        }
    }

}
