using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    GameObject Chupacabra, Bigfoot;
    Vector3 localScale;
    float health;
    float last;
    bool temp;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.ChupaLevelBeaten == false)
        {
            health = Chupacabra.GetComponent<Health>().GetMax();
            temp = true;
        }
        else
            health = Bigfoot.GetComponent<Health>().GetMax();

        last = health;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (temp == true)
        {
            health = Chupacabra.GetComponent<Health>().GetHealth();//get current health
            localScale.x = localScale.x * (health / last);//reduces in size when it just took damage
            last = health;//remember last health value
            transform.localScale = localScale;//set local scaling
        }
        else
        {
            health = Bigfoot.GetComponent<Health>().GetHealth();//get current health
            localScale.x = localScale.x * (health / last);//reduces in size when it just took damage
            last = health;//remember last health value
            transform.localScale = localScale;//set local scaling
        }
       

    }
}
