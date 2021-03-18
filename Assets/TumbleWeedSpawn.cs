using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeedSpawn : MonoBehaviour
{
    public GameObject TumbleWeed;
    public GameObject tumbleweedspawn;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(TumbleWeed, tumbleweedspawn.transform.position, Quaternion.identity); 
        TumbleWeed.transform.position = new Vector3 (TumbleWeed.transform.position.x + (speed * Time.deltaTime), TumbleWeed.transform.position.y, 0f);
        TumbleWeed.transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);

    }
}
