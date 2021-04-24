using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChupacabraFightAI : MonoBehaviour
{
    GameObject player;
    private PlayerDeath playerHealth;
    private float idle; //Trigger for idle state
    public float trappedTime = 5f;
    public AudioSource pouncesound;

    [SerializeField]
    private Rigidbody2D rb; //Rigidbody used for chupa physics

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Transform child;

    [SerializeField]
    private SpriteRenderer rend;

    private Health health;

    public float baseSpeed = 5f; //Base speed of the Cabra
    public float pounceSpeedMod = 1.8f; //Modifier to base speed during pounce cycle. 1 is no change. Should be greater than 1
    public float slowSpeedMod = 0.5f; //Modifier to base speed during slowdown. 1 is no change. Should be less than 1.

    public float strafeDistance = 10f; //Distance Cabra tries to maintain from player while strafing.
    public float strafeThreshold = 2f; //Cushion for strafeDistance so the Cabra isn't trying to constantly maintain the same distance from the player
    int strafeDirection = 1; //Contains the current strafe direction. 1 for right, -1 for right
    public float strafeChangeTime = 2f; //Time between cabra changing directions while strafing
    public float strafeChangeTimeVariance = 1f; //Degree of variability in the time between strafe changes to introduce variance.
    private float strafeChangeTimer; //Tracker for the time between strafe changes

    public float pounceTime = 8f; //Time between pounce phases
    public float pounceTimeVariance = 2f; //Degree of variability between pounce phases
    private float pounceTimer; //Tracker for the time between pounce phases

    public int pounceAmount = 3; //Amount of pounces per pounce phase
    public float timeBetweenPounces = 1f; //The timing between each pounce during the pounce phase
    private float betweenPounceTimer; //Tracker for the time between pounces
    private int pounceCounter; //Counts the amount of times pounced during the pounce phase
    //private float pouncePhaseTimer; //timer to keep track of certain timings in pounce phase
    private int pouncePhase; //counter to keep track of which phase of the pounce we are in
    private GameObject staticPoint; //Stores position of player at beginning of pounce 
    private bool passedPoint; //flag for whether or not the cabra has triggered staticPoint during the current pounce

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;

        idle = 0f;
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerDeath>();

        health = gameObject.GetComponent<Health>();

        strafeChangeTimer = strafeChangeTime + Random.Range(-strafeChangeTimeVariance, strafeChangeTimeVariance);
        pounceTimer = pounceTime + Random.Range(-pounceTimeVariance, pounceTimeVariance);

        staticPoint = GameObject.FindWithTag("StaticPoint");

        pounceCounter = 0;
        pouncePhase = 1;
        betweenPounceTimer = timeBetweenPounces;
    }

    void Update()
    {

        rb.velocity = new Vector2(0.0f, 0.0f); //Constantly removes any velocity to combat the physics system. Remove if converting to using physics instead of translation

        //TODO::Create a funtion to keep the chupa's rotation within the bounds of 0 and 360 without affecting it's actual rotation
        //first, make sure the rotation is positive
        if(transform.rotation.eulerAngles.z < 0f)
        {
            MakeRotationPositive();
        }

        //then, use fmod to force the bonds between 0 and 360
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, transform.rotation.eulerAngles.z % 360);

        anim.SetFloat("rotation", transform.rotation.eulerAngles.z); //gives the chupa's current rotation to the animator for animating reasons

        //Idle trigger
        if(Input.GetKeyDown(KeyCode.I))
        {
            idle = trappedTime;
        }
        
        //If not idle, figure out the current state of the cabra
        if (idle <= 0f)
        {
            anim.SetBool("active", true);
            //If pounceTimer isn't 0, cabra is in strafe mode
            if(pounceTimer > 0)
            {
                StrafeMode();
            }
            //Otherwise, the cabra is in pounce mode
            else
            {
                PounceMode();
            }
        }
        else
        {
            idle = Mathf.Max(idle - Time.deltaTime, 0);
            anim.SetBool("active", false);
        }
    }

    //Chupacabra circles the player, keeping a steady distance until pounce phase
    void StrafeMode()
    {
        //Make cabra face the player
        transform.right = player.transform.position - transform.position;
        child.rotation = Quaternion.Euler(0f, 0f, -transform.rotation.z);

        //Checks if it's time to change directions
        if(strafeChangeTimer < 0)
        {
            strafeDirection *= -1;
            strafeChangeTimer = strafeChangeTime + Random.Range(-strafeChangeTimeVariance, strafeChangeTimeVariance);
        }

        //Move in the correct strafe direction
        transform.Translate(Vector2.down * baseSpeed * strafeDirection * Time.deltaTime);

        //Change sprite rendering based on which way chupa is facing
        if(strafeDirection > 0)
        {
            anim.SetBool("runningClockwise", false);
            //rend.flipY = false;  //This parameter is outdated. Will remove soon 
        }
        else
        {
            anim.SetBool("runningClockwise", true);
            //rend.flipY = true;
        }

        //If the distance between cabra and player is off the strafeDistance by a magnitude greater than the strafeThreshold, call StrafeAdjustment
        if (Mathf.Abs(strafeDistance - Vector2.Distance(transform.position, player.transform.position)) > strafeThreshold) 
        {
            StrafeAdjustment();
        }

        //Countdown active timers
        strafeChangeTimer -= Time.deltaTime;
        pounceTimer -= Time.deltaTime;       
    }

    //Helps Chupacabra keep a steady distance during strafe mode, moving away from player if they're too close and towards them if too far
    void StrafeAdjustment()
    {
        //If the distance between the player and the cabra is greater than the strafeDistance, close the gap
        if(Vector2.Distance(transform.position, player.transform.position) > strafeDistance)
        {
            transform.Translate(Vector2.right * baseSpeed * Time.deltaTime);
        }
        //Otherwise, open the gap
        else if(Vector2.Distance(transform.position, player.transform.position) < strafeDistance)
        {
            transform.Translate(Vector2.left * baseSpeed * Time.deltaTime);
        }
    }

    //Chupacabra slows down their circling for a moment, then springs at the player's current location, repeating pounceAmount times then returning to strafe
    void PounceMode()
    {
        //Phase 1: Telegraph
        if (pouncePhase == 1)
        {
            //Briefly continue circling at a slowed speed to telegraph a pounce
            transform.right = player.transform.position - transform.position;
            child.rotation = Quaternion.Euler(0f, 0f, -transform.rotation.z);
            transform.Translate(Vector2.down * baseSpeed * slowSpeedMod * strafeDirection * Time.deltaTime);

            //countdown phase
            betweenPounceTimer -= Time.deltaTime;

            //switch to phase 2
            if (betweenPounceTimer < 0)
            {
                pouncePhase = 2;
            }
        }

        //Phase 2:Setup
        else if (pouncePhase == 2)
        {
            //change animator's pounce bool to true to help animations line up properly
            anim.SetBool("pouncing", true);

            //reset passedPoint
            passedPoint = false;

            //update staticPoint
            staticPoint.transform.position = player.transform.position;

            //Face the storedPosition
            transform.right = staticPoint.transform.position - transform.position;
            child.rotation = Quaternion.Euler(0f, 0f, -transform.rotation.z);

            //Reset betweenPounceTimer
            if (pounceCounter < pounceAmount - 1)
                betweenPounceTimer = timeBetweenPounces;
            else
                betweenPounceTimer = timeBetweenPounces * 2;

            //Debug.Log("Pounce Counter: " + pounceCounter);

            //switch to phase 3
            pouncePhase = 3;
        }

        //Phase 3:Pounce
        else if (pouncePhase == 3)
        {
            //If cabra hasn't passed staticPoint, head towards it at pounce speed
            if (passedPoint == false)
            {
                pouncesound.Play();
                transform.Translate(Vector2.right * baseSpeed * pounceSpeedMod * Time.deltaTime);
            }
            //If it has, slow it down
            else
            {
                transform.Translate(Vector2.right * baseSpeed * slowSpeedMod * Time.deltaTime);
            }

            //countdown
            betweenPounceTimer -= Time.deltaTime;

            //phase switch if phase is done
            if (betweenPounceTimer < 0)
            {
                //if that was the last pounce, switch to phase 4
                if (pounceCounter >= pounceAmount - 1)
                {
                    pouncePhase = 4;
                }
                //if not, go back to phase 2
                else
                {
                    pounceCounter++;
                    pouncePhase = 2;
                }
            }
        }

        //Phase 4:Resolution
        else if (pouncePhase == 4)
        {
            //stop making pounce noises
            pouncesound.Stop();

            //Make sure the animator starts drawing the chupa's animations for strafing properly
            anim.SetBool("pouncing", false);

            //Reset the pounce counter
            pounceCounter = 0;

            //set pouncePhase to 1
            pouncePhase = 1;

            //reset betweenPounceTimer
            betweenPounceTimer = timeBetweenPounces;

            //reset the pounceTimer
            pounceTimer = pounceTime + Random.Range(-pounceTimeVariance, pounceTimeVariance);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))//Take damage if shot
        {
            health.TakeDamage();
        }
        if(collision.gameObject == player)//If run into player, deal damage to player
        {
            playerHealth.TakeDamage();
        }

    }

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.gameObject.tag == "trap"){
            trigger.GetComponent<Trap>().Shut();
            idle = trappedTime;
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        //slow down pounce if hitbox passed was staticPoint
        if(trigger.gameObject.tag == "StaticPoint")
            passedPoint = true;
    }

    //recursive function that guaruntees that the chupa's rotation is positive
    void MakeRotationPositive()
    {
        //modify the rotation by one full rotation
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, transform.rotation.eulerAngles.z + 360);

        //If the rotation isn't yet positive, do it again

        if(transform.rotation.eulerAngles.z < 0)
        {
            MakeRotationPositive();
        }
    }

}
