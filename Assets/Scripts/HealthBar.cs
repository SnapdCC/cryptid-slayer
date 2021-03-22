using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    GameObject Chupacabra;
    Vector3 localScale;
    float health;
    float last;
    // Start is called before the first frame update
    void Start()
    {
        health = Chupacabra.GetComponent<Health>().GetMax();
        last = health;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        health = Chupacabra.GetComponent<Health>().GetHealth();//get current health
        localScale.x = localScale.x*(health/last);//reduces in size when it just took damage
        last=health;//remember last health value
        transform.localScale = localScale;//set local scaling
    }
}
