using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootFightAI : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    private Rigidbody2D rb;

    //Enum used to control finite state machine
    private enum State { IDLE, STALKING, SLASH, CHARGE, STUCK, TRAP_CRUSH }
    private State currentState;

    //Bigfoot's general stats
    [SerializeField]
    private float baseSpeed = 2f; //Base speed of bigfoot. Used when he's stalking as well as the base for the other speeds.
    [SerializeField]
    private float topSpeedMod = 3f; //Modifier used with baseSpeed to determine topSpeed
    private float topSpeed; //Top speed of bigfoot
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
    private float stuckTime = 5f; //Time bigfoot is stuck in a pitfall
    private float stuckTimer; //Keeps track of stuck time

    //NOTE:Since I think Slash and Trap Crush are states that last as long as their animation, I am not adding any times into the code
    //NOTE TO SELF: Ask Professor how to base timings on animations

    //Charge variables
    [SerializeField]
    private float chargeTrackingCutoff = 3f; //Cutoff distance where bigfoot stops tracking the player's current location
    private bool chargePositionSet;

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;

        player = GameObject.FindWithTag("Player");

        currentState = State.IDLE;

        topSpeed = baseSpeed * topSpeedMod;
        chargeWaitTimer = chargeWaitTime + Random.Range(-chargeWaitTimeVariance, chargeWaitTimeVariance);
        chargePositionSet = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Finite State Machine
        if (currentState = State.IDLE)
        {
            Idle();
        }
        else if (currentState = State.STALKING)
        {
            Stalking();
        }
        else if (currentState = State.SLASH)
        {
            Slash();
        }
        else if(currentState = State.CHARGE)
        {
            Charge();
        }
        else if(currentState = State.STUCK)
        {
            Stuck();
        }
        else if(currentState = State.TRAP_CRUSH)
        {
            TrapCrush();
        }

    }

    void Idle()
    {

    }

    //Default State. Slowly lumbers toward player 
    void Stalking()
    {
        //Rotate to face the player

        //Move towards player at base speed

        //count down chargeWaitTimer

        //If player is in slashing range, change state to Slash

        //If chargeWaitTimer is less than 0, reset chargePositionSet and change states to Charge
    }
    
    //Happens when player is too close. Bigfoot slashes with the axe he stole from the player
    void Slash()
    {
        //Play Slash animation and activate slash hitbox

        //Afterwards, change state to Stalking
    }

    //Happens after enough time away from player. Bigfoot picks up speed and charges at the player
    void Charge()
    {
        //If chargePositionSet is false, continue to target player while interpolating to top speed

        //otherwise, wait until bigfoot passes the staticPoint, then interpolate speed down to zero

        //Afterwards, start tracking player while interpolating up to base speed. Once base speed is met, reset chargeWaitTimer and set state to Stalking
    }

    //Happens when bigfoot collides with a pitfall
    void Stuck()
    {
        //Lock bigfoot in place for the duration of stuckTimer. Make it so all hitboxes take damage, not just the rear

        //Afterwards, disable pitfall and set state to Stalking
    }

    //Happens when bigfoot collides with a bear trap
    void TrapCrush()
    {
        //Delete trap, play trap crush animation while keeping bigfoot in place

        //Afterwards, set state to Stalking
    }

    OnTriggerEnter2D(Collider2D other)
    {

    }
}
