using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChup : MonoBehaviour
{
    public GameObject chupacabra;
    // Start is called before the first frame update
    void Start()
    {
        chupacabra.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chupacabra.SetActive(true);
    }
}
