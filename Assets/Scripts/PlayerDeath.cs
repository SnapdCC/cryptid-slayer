using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public static float health;
    public int damagecount;
    public Image FullHeart1;
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
        health = 4.0f;
        damagecount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HeartManagement();
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Cryptid"))
        {
            damagecount++;
            health = health - .25f;
        }
    }

    void HeartManagement()
    {
        if (damagecount == 1)
        {
            FullHeart1.enabled = false;
            ThreeQuarterHeart1.enabled = true;
            FullHeart2.enabled = false;
            ThreeQuarterHeart2.enabled = true;
            FullHeart3.enabled = false;
            ThreeQuarterHeart3.enabled = true;
        }
        if (damagecount == 2)
        {
            ThreeQuarterHeart1.enabled = false;
            HalfHeart1.enabled = true;
            FullHeart2.enabled = false;
            ThreeQuarterHeart2.enabled = true;
            FullHeart3.enabled = false;
            ThreeQuarterHeart3.enabled = true;

        }
        if (damagecount == 3)
        {
            HalfHeart1.enabled = false;
            QuarterHeart1.enabled = true;
            FullHeart2.enabled = false;
            ThreeQuarterHeart2.enabled = true;
            FullHeart3.enabled = false;
            ThreeQuarterHeart3.enabled = true;
        }
        if (damagecount == 4)
        {
            QuarterHeart1.enabled = false;
            QuarterHeart2.enabled = false;
            QuarterHeart3.enabled = false;
        }


    }
}
