using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject bullet;
    public GameObject wintext;
    private GameManager manager;
    
    [SerializeField]
    private string WinScreen;
    float health;
    [SerializeField]
    public float MaxHealth = 1f;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(WinScreen);
        }
    }

    public float GetHealth(){
        return health;
    }

    public float GetMax(){
        return MaxHealth;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            //Destroy(collision.gameObject);
            
            health = health - .125f;
        }
    }
}
