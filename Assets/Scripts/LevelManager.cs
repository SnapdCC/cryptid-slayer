using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameManager GameManager;
    [SerializeField]
    private GameObject ChupBeaten;
    [SerializeField]
    private GameObject JackBeaten;
    [SerializeField]
    private GameObject SquatchBeaten;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Debug.Log(GameManager.gameObject.scene);
        ChupBeaten.SetActive(GameManager.ChupIsBeat());
        JackBeaten.SetActive(GameManager.JackIsBeat());
        SquatchBeaten.SetActive(GameManager.SquatchIsBeat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
