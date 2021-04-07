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
        if (collision.gameObject.tag.Equals("Jackalope"))
        {
            Debug.Log("it worked!");
            Destroy(spawnmanager);

        }
    }




}
