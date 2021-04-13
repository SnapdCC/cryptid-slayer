using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    
    private SpriteRenderer trapSprite;
    [SerializeField]
    private Sprite trapOpen;
    [SerializeField]
    private Sprite trapClose; 
    private bool isShut;
    public float catchTime = 5.0f;
    public GameObject spawnmanager;
    public static bool invistrapactive = false;
    // Start is called before the first frame update
    void Start()
    {
        trapSprite = GetComponent<SpriteRenderer>();
        isShut = false;
        
    }

    public void Shut(){
        if(!isShut){
            trapSprite.sprite = trapClose;
            isShut = true;
            Destroy(gameObject, 5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) == true){
            Shut();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "InvisTrap" && collision.gameObject.tag.Equals("Player"))
        {
            Shut();
            PlayerDeath.damagecount++;
        }
        if (collision.gameObject.tag.Equals("Jackalope"))
        {
            Debug.Log("it worked!");
            Destroy(spawnmanager);

        }
    }




}
