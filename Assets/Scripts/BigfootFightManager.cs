using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootFightManager : MonoBehaviour
{
    private Health bigfootHealth;
    [SerializeField]
    private Animator anim;

    private GameObject player;
    private PlayerDeath playerHealth;

    private GameObject staticPoint;

    [SerializeField]
    private Rigidbody2D rb;

    //enum used to keep track of the current state
    public enum BigfootState { Idle, Stalking, Charging, Slashing, Stuck };
    private BigfootState currentState;


    //Bigfoot's general stats
    [SerializeField]
    private float acceleration = 1f; //how fast bigfoot changes speed

    [SerializeField]
    private float baseSpeed = 2f; //Base speed of bigfoot. Used when he's stalking as well as the base for the other speeds.
    [SerializeField]
    private float topSpeedMod = 3f; //Modifier used with baseSpeed to determine topSpeed
    private float topSpeed; //Top speed of bigfoot
    private float currentSpeed = 0f;//Keeps track of bigfoot's current speed
    [SerializeField]
    private int slashDamage = 2; //Damage done on a slash hit
    [SerializeField]
    private int chargeDamage = 1; //Damage done on a charge hit

    //Timings
    
    [SerializeField]
    private float chargeWaitTime = 8f; //Time between charges
    [SerializeField]
    private float chargeWaitTimeVariance = 2f; //Variability of charge times
    private float chargeWaitTimer; //Timer used to keep track of the time between charges

    [SerializeField]
    private float chargeCooldownTime = 2f;

    [SerializeField]
    private float stuckTime = 5f; //Time bigfoot is stuck in a pitfall
    private float stuckTimer; //Keeps track of stuck time


    //Slash variables
    [SerializeField]
    private float slashDistance = 2f;//Distance from bigfoot the player is before he starts slashing

    private bool playerWasSlashed = false; //keeps track of whether the player's been hit by a slash attack in the current slash attack

    //Charge variables
    [SerializeField]
    private float chargeTrackingCutoff = 3f; //Cutoff distance where bigfoot stops tracking the player's current location

    private bool chargePositionPassed; //keeps track of whether bigfoot's passed the staticPoint during a charge

    //getters and setters
    public GameObject Player { get => player; }
    public Rigidbody2D Rb { get => rb; }
    public float Acceleration { get => acceleration; }
    public float BaseSpeed { get => baseSpeed; }
    public float TopSpeed { get => topSpeed; }
    public int SlashDamage { get => slashDamage; }
    public int ChargeDamage { get => chargeDamage; }
    public float ChargeWaitTime { get => chargeWaitTime; }
    public float ChargeWaitTimeVariance { get => chargeWaitTimeVariance; }
    public float ChargeWaitTimer { get => chargeWaitTimer; set => chargeWaitTimer = value; }
    public float StuckTime { get => stuckTime; }
    public float StuckTimer { get => stuckTimer; set => stuckTimer = value; }
    public float CurrentSpeed { get => currentSpeed; set => currentSpeed = value; }
    public GameObject StaticPoint { get => staticPoint; }
    public float ChargeTrackingCutoff { get => chargeTrackingCutoff; }
    public float ChargeCooldownTime { get => chargeCooldownTime; }
    public BigfootState CurrentState { get => currentState; set => currentState = value; }
    public bool ChargePositionPassed { get => chargePositionPassed; set => chargePositionPassed = value; }
    public PlayerDeath PlayerHealth { get => playerHealth; }
    public Health BigfootHealth { get => bigfootHealth; }
    public float SlashDistance { get => slashDistance; }
    public bool PlayerWasSlashed { get => playerWasSlashed; set => playerWasSlashed = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;

        currentState = BigfootState.Idle;

        bigfootHealth = gameObject.GetComponent<Health>();

        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerDeath>();

        staticPoint = GameObject.FindWithTag("StaticPoint");

        topSpeed = baseSpeed * topSpeedMod;
        chargeWaitTimer = chargeWaitTime + Random.Range(-chargeWaitTimeVariance, chargeWaitTimeVariance);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0.0f, 0.0f); //Constantly removes any velocity to combat the physics system. Remove if converting to using physics instead of translation

    }

    //Use to change the bigfoot speed by the bigfoot's acceleration
    public void InterpolateSpeed(float endSpeed)
    {
        float pastSpeed = currentSpeed;

        //Interpolate towards the endSpeed by the rate of acceleration
        if (currentSpeed > endSpeed)
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }
        else if (currentSpeed < endSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        if(currentSpeed < pastSpeed && currentSpeed < endSpeed || currentSpeed > pastSpeed && currentSpeed > endSpeed)//If the change overshot, set currentSpeed to the endSpeed
        {
            currentSpeed = endSpeed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(currentState == BigfootState.Charging)
        {
            if(collision.gameObject.tag == "Player")
            {
                for(int i = 0; i < chargeDamage; i++)
                    playerHealth.TakeDamage();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(currentState == BigfootState.Charging)
        {
            if(trigger.gameObject.tag == "StaticPoint")
            {
                chargePositionPassed = true;
            }
        }
        
    }
}
