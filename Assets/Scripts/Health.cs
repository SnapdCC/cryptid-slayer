using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject bullet;
    public GameObject wintext;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("WinScreen");
            //wintext.SetActive(true);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            //Destroy(collision.gameObject);
            
            health = health - .25f;
        }
    }
}
