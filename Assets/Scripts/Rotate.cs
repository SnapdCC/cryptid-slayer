using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //adjust this to change speed
    float speed = 5f;
    //adjust this to change how high it goes
    float height = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*//get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, 0) * height;
        */// Rotate thet transform of the game object this is attached to by 45 degrees, taking into account the time elapsed since last frame.
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }
}
