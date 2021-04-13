using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigfootStalking : StateMachineBehaviour
{
    private GameObject bigfoot;
    private BigfootFightManager manager;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bigfoot = GameObject.FindWithTag("Cryptid");
        manager = bigfoot.GetComponent<BigfootFightManager>();

        //modify hitbox behavior here
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Rotate to face the player
        bigfoot.transform.right = manager.Player.transform.position - bigfoot.transform.position;
        
        //if the current speed isn't base speed, interpolate towards base speed
        if(manager.CurrentSpeed < manager.BaseSpeed || manager.CurrentSpeed > manager.BaseSpeed)
        {
            manager.InterpolateSpeed(manager.BaseSpeed);
        }

        //Move towards player at current speed
        bigfoot.transform.Translate(Vector2.right * manager.CurrentSpeed * Time.deltaTime);

        //count down chargeWaitTimer
        manager.ChargeWaitTimer -= Time.deltaTime;
        
        //If player is in slashing range, change state to Slash

        //If chargeWaitTimer is less than 0, reset chargePositionSet and change states to Charge    
        if(manager.ChargeWaitTimer <= 0)
        {
            animator.Play("Base Layer.Charge Down");
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

