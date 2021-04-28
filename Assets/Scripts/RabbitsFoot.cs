using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitsFoot : MonoBehaviour
{
    public float sprintTime = 2.5f;
    private float currentSprint;
    public SpriteRenderer sprite;
    private PlayerMovement pm;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        currentSprint = sprintTime;
        scale = transform.localScale;
        pm=transform.parent.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.LeftShift)&&pm.GameManager.JackLevelBeaten)
        {
            if(currentSprint>0){
                pm.sprinting = true;
                currentSprint = Mathf.Max(0, currentSprint-Time.deltaTime);
            }
            else
            {
                pm.sprinting = false;
            }
        }
        else
        {
            pm.sprinting = false;
            currentSprint = Mathf.Min(sprintTime, currentSprint+(Time.deltaTime/2));
        }
        // Debug.Log(currentSprint);
        scale.x=currentSprint/sprintTime;
        if(scale.x == 1f)
        {
            sprite.enabled = false;
        } else
        {
            sprite.enabled = true;
            transform.localScale=scale;
        }
    }
}
