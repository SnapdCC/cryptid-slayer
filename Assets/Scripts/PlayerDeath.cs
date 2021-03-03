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
    public Image FullHeart1; // Images for full, half, 3/4, and 1/4 hearts
    public Image FullHeart2;
    public Image FullHeart3;
    public Image ThreeQuarterHeart1;
    public Image ThreeQuarterHeart2;
    public Image ThreeQuarterHeart3;
    public Image HalfHeart1;
    public Image HalfHeart2;
    public Image HalfHeart3;
    public Image QuarterHeart1;
    public Image QuarterHeart2;
    public Image QuarterHeart3;
    
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
        if (collision.gameObject.tag.Equals("Cryptid"))
        {
            damagecount++;
            //health = health - .25f;
        }
        
    }
    
        void HeartManagement() // For each damage count the correct heart images are displayed based on the count
    {
        if (damagecount == 1)
        {
            FullHeart1.enabled = false;
            ThreeQuarterHeart1.enabled = true;
        }
        if (damagecount == 2)
        {
            ThreeQuarterHeart1.enabled = false;
            HalfHeart1.enabled = true;
        }
        if (damagecount == 3)
        {
            HalfHeart1.enabled = false;
            QuarterHeart1.enabled = true;
        }
        if (damagecount == 4)
        {
            QuarterHeart1.enabled = false;
        }
        if (damagecount == 5)
        {
            FullHeart2.enabled = false;
            ThreeQuarterHeart2.enabled = true;
        }
        if (damagecount == 6)
        {
            ThreeQuarterHeart2.enabled = false;
            HalfHeart2.enabled = true;
        }
        if (damagecount == 7)
        {
            HalfHeart2.enabled = false;
            QuarterHeart2.enabled = true;
        }
        if (damagecount == 8)
        {
            QuarterHeart2.enabled = false;
        }
        if (damagecount == 9)
        {
            FullHeart3.enabled = false;
            ThreeQuarterHeart3.enabled = true;
        }
        if (damagecount == 10)
        {
            ThreeQuarterHeart3.enabled = false;
            HalfHeart3.enabled = true;
        }
        if (damagecount == 11)
        {
            HalfHeart3.enabled = false;
            QuarterHeart3.enabled = true;
        }
        if (damagecount == 12)
        {
            QuarterHeart3.enabled = false;
        }


    }
}
