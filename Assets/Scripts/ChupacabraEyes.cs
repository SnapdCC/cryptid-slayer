using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChupacabraEyes : MonoBehaviour
{
    GameObject[] List;
    SpriteRenderer trap;
    [SerializeField]
    GameObject panel;


    // Update is called once per frame
    void Update()
    {
        List = GameObject.FindGameObjectsWithTag("InvisTrap");

        if (Input.GetButtonDown("Fire3"))
        {
            panel.SetActive(true);
                foreach (GameObject item in List)
            {
                trap = item.GetComponent<SpriteRenderer>();
                trap.enabled = true;
            }
        }
        else if(Input.GetButtonUp("Fire3"))
        {
            panel.SetActive(false);
            foreach (GameObject item in List)
            {
                trap = item.GetComponent<SpriteRenderer>();
                trap.enabled = false;
            }
        }
    }
}
