using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public static float health;
    bool activetrap;
    public float testdamage;
    public static float damagecount; // damagecount variable records # of times player has been hit
    public Image Heart1; // Images for full, half, 3/4, and 1/4 hearts
    public Image Heart2;
    public Image Heart3;

    public Sprite HeartFull;
    public Sprite HeartMore;
    public Sprite HeartHalf;
    public Sprite HeartLess;
    
    // Start is called before the first frame update
    void Start()
    {
        //health = 4.0f;
        damagecount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HeartManagement();
        testdamage = damagecount;

        if (damagecount == 12)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScreen");
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag.Equals("smoke"))
        {
            damagecount++;
            //health = health - .25f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) // Detects collisions between player and cryptid
    {
        GameObject body = collision.gameObject;
        Debug.Log(body.tag);
        if (body.tag.Equals("Health"))
        {
            
            damagecount=0;
            Destroy(body);
        }
        
    }

    public void TakeDamage()
    {
        damagecount++;
    }
    
    void HeartManagement() // For each damage count the correct heart images are displayed based on the count
    {
        if(damagecount == 0) {
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartFull;
            Heart3.sprite = HeartFull;
        }
        if (damagecount == 1)
        {
            //2 Full, 1 3/4
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartFull;
            Heart3.sprite = HeartMore;
        }
        if (damagecount == 2)
        {
            //2 full, 1 1/2
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartFull;
            Heart3.sprite = HeartHalf;
        }
        if (damagecount == 3)
        {
            //2 Full, 1 1/4
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartFull;
            Heart3.sprite = HeartLess;
        }
        if (damagecount == 4)
        {
            //2 Full, 1 Empty
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartFull;
            Heart3.enabled =false;
        }
        if (damagecount == 5)
        {
            //1 Full, 1 3/4
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartMore;
            Heart3.enabled =false;
        }
        if (damagecount == 6)
        {
            //1 Full, 1 1/2
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartHalf;
            Heart3.enabled =false;
        }
        if (damagecount == 7)
        {
            //1 Full, 1 1/4
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartLess;
            Heart3.enabled =false;
        }
        if (damagecount == 8)
        {
            //1 Full, 2 Empty
            Heart1.sprite = HeartFull;
            Heart2.enabled = false;
            Heart3.enabled =false;
        }
        if (damagecount == 9)
        {
            //1 3/4
            Heart1.sprite = HeartMore;
            Heart2.enabled = false;
            Heart3.enabled = false;
        }
        if (damagecount == 10)
        {
            //1 1/2
            Heart1.sprite = HeartHalf;
            Heart2.enabled = false;
            Heart3.enabled = false;
        }
        if (damagecount == 11)
        {
            //1 1/4
            Heart1.sprite = HeartLess;
            Heart2.enabled = false;
            Heart3.enabled = false;
        }
        if (damagecount == 12)
        {
            //3 Empty, Dead
            Heart1.enabled = false;
            Heart2.enabled = false;
            Heart3.enabled = false;
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
