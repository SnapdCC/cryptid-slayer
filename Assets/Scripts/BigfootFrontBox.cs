using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootFrontBox : MonoBehaviour
{
    private BigfootFightManager manager;
    private AudioSource deflect;

    [SerializeField]
    private AudioClip deflectNoise;

    // Start is called before the first frame update
    void Start()
    {
        //initialize manager
        manager = gameObject.GetComponentInParent<BigfootFightManager>();
        deflect = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag.Equals("bullet"))
        {
            deflect.PlayOneShot(deflectNoise, 1f);
            Destroy(trigger.gameObject);
        }
    }
}
