using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeedSpawn : MonoBehaviour
{
    public GameObject TumbleWeed;
    public GameObject tumbleweedspawn;
    public int speed;
    public GameObject clone;
    public float Timer = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            clone = Instantiate(TumbleWeed, new Vector3(tumbleweedspawn.transform.position.x, tumbleweedspawn.transform.position.y, tumbleweedspawn.transform.position.z), transform.rotation) as GameObject;
            Timer = 30f;

        }
        clone.transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);
        clone.transform.position = new Vector3(clone.transform.position.x + (speed * Time.deltaTime), clone.transform.position.y, 0f);
        //Instantiate(TumbleWeed, tumbleweedspawn.transform.position, Quaternion.identity); 
        //TumbleWeed.transform.position = new Vector3 (TumbleWeed.transform.position.x + (speed * Time.deltaTime), TumbleWeed.transform.position.y, 0f);
        //TumbleWeed.transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);

    }
}
