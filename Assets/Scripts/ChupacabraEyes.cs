using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChupacabraEyes : MonoBehaviour
{
    public GameObject[] List;
    Material item_material;
    public GameObject panel;


    // Update is called once per frame
    void Update()
    {
        List = GameObject.FindGameObjectsWithTag("TumbleWeed");

        if (Input.GetKey(KeyCode.Q) == true)
        {
            panel.SetActive(true);
                foreach (GameObject item in List)
            {
                item_material = item.GetComponent<Renderer>().material;
                item_material.color = Color.yellow;
            }
        }
        else
        {
            panel.SetActive(false);
            foreach (GameObject box in List)
            {
                item_material = box.GetComponent<Renderer>().material;
                item_material.color = Color.white;
            }
        }
            

        
    }
}
