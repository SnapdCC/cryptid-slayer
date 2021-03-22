using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChup : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;

    public GameObject chupacabra;
    // Start is called before the first frame update
    void Start()
    {
        chupacabra.GetComponent<ChupacabraFightAI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        healthBar.SetActive(true);
        chupacabra.GetComponent<ChupacabraFightAI>().enabled = true;
    }
}
