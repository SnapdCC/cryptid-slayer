using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootCharging : StateMachineBehaviour
{
    private GameObject bigfoot;
    private BigfootFightManager manager;

    private bool chargePositionSet;

    private float chargeCooldownTimer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bigfoot = GameObject.FindWithTag("Cryptid");
        manager = bigfoot.GetComponent<BigfootFightManager>();

        manager.CurrentState = BigfootFightManager.BigfootState.Charging;

        //modify hitbox behavior here
        manager.StaticPoint.SetActive(false);

        chargePositionSet = false;
        manager.ChargePositionPassed = false;

        chargeCooldownTimer = manager.ChargeCooldownTime;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //If chargePositionSet is false, continue to target player while interpolating to top speed
        if (chargePositionSet == false)
        {
            //Rotate to face the player
            bigfoot.transform.right = manager.Player.transform.position - bigfoot.transform.position;

            //if the current speed isn't base speed, interpolate towards base speed
            if (manager.CurrentSpeed < manager.TopSpeed || manager.CurrentSpeed > manager.TopSpeed)
            {
                manager.InterpolateSpeed(manager.TopSpeed);
            }

            //Move towards player at current speed
            bigfoot.transform.Translate(Vector2.right * manager.CurrentSpeed * Time.deltaTime);

            //If the distance is less than the set cutoff distance for tracking, set the static point position and set ChargeSetPosition to true
            if (Vector3.Distance(bigfoot.transform.position, manager.Player.transform.position) < manager.ChargeTrackingCutoff)
            {
                manager.StaticPoint.SetActive(true);
                manager.StaticPoint.transform.position = manager.Player.transform.position;
                chargePositionSet = true;
            }
        }
        //otherwise, keep going straight until bigfoot passes the staticPoint
        else if (chargePositionSet == true && manager.ChargePositionPassed == false)
        {
            //if the current speed isn't base speed, interpolate towards base speed
            if (manager.CurrentSpeed < manager.TopSpeed || manager.CurrentSpeed > manager.TopSpeed)
            {
                manager.InterpolateSpeed(manager.TopSpeed);
            }

            //Move towards player at current speed
            bigfoot.transform.Translate(Vector2.right * manager.CurrentSpeed * Time.deltaTime);
        }
        //once the staticPoint has been passed, interpolate to zero speed, pause for a moment, then go back to stalking
        else
        {
            //If bigfoot isn't stopped, slow down
            if(manager.CurrentSpeed > 0)
            {
                //interpolate to zero
                manager.InterpolateSpeed(0.0f);

                //Move towards player at current speed
                bigfoot.transform.Translate(Vector2.right * manager.CurrentSpeed * Time.deltaTime);
            }
            //Once bigfoot is stopped, wait for a couple seconds
            else if(chargeCooldownTimer > 0)
            {
                //count down chargeCooldownTimer
                chargeCooldownTimer -= Time.deltaTime;
                Debug.Log("chargeCooldown: " + chargeCooldownTimer);
            }
            //Once everything else is done, go back to stalking
            else
            {
                manager.ChargeWaitTimer = manager.ChargeWaitTime + Random.Range(-manager.ChargeWaitTimeVariance, manager.ChargeWaitTimeVariance);
                animator.Play("Base Layer.Stalking Down");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}


}
