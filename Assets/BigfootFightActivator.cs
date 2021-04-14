using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootFightActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject bigfoot;

    private Animator bigfootAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bigfootAnimator = bigfoot.GetComponent<Animator>();
        bigfootAnimator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")
        {
            bigfootAnimator.SetBool("Idle", false);
        }
    }
}
