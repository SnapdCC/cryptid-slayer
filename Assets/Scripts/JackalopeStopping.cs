using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JackalopeStopping : MonoBehaviour
{
    public GameObject spawnmanager;
    public bool jackalope_caught;
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("Got caught");
        Debug.Log(trigger.gameObject.tag);
        if (trigger.gameObject.CompareTag("trap"))
        {
            Debug.Log("Does if work");
            trigger.GetComponent<Trap>().Shut();
            jackalope_caught = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jackalope_caught == true && collision.gameObject.CompareTag("Player"))
        {
            manager.JackLevelBeaten = true;
            SceneManager.LoadScene("JackalopeWin");
        }
    }
}
