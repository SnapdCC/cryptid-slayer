using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject bullet;
    
    [SerializeField]
    private string WinScreen;
    float health;
    [SerializeField]
    public float MaxHealth = 4f;
    // Start is called before the first frame update
    void Start()
    {
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

    public void TakeDamage()
    {
        health = health - .125f;
    }
    
}
