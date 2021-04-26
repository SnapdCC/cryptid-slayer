using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootBackBox : MonoBehaviour
{
    private BigfootFightManager manager;
    private AudioSource hurt;

    [SerializeField]
    private AudioClip hurtNoise;

    // Start is called before the first frame update
    void Start()
    {
        //initialize manager
        manager = gameObject.GetComponentInParent<BigfootFightManager>();

        hurt = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag.Equals("bullet"))
        {
            hurt.PlayOneShot(hurtNoise, 1f);
            manager.BigfootHealth.TakeDamage();
        }
    }
}
