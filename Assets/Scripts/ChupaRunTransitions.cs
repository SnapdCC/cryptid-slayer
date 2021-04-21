using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChupaRunTransitions : StateMachineBehaviour
{
    private SpriteRenderer chupaSprite;

     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        chupaSprite = animator.gameObject.GetComponent<SpriteRenderer>(); 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float rotation = animator.GetFloat("rotation");

        //if the chupa is strafing, play the right animation based on the chupa's rotation as well as whether it's currently running clockwise
        if (!animator.GetBool("pouncing"))
        {
            //running down
            if ((rotation > 315f || rotation > 0f && rotation < 45f) && !animator.GetBool("runningClockwise") || (rotation > 135f && rotation < 225f) && animator.GetBool("runningClockwise"))
            {
                chupaSprite.flipX = false;
                animator.Play("Base Layer.ChupaRunDown");
            }
            //running up
            else if ((rotation > 315f || rotation > 0f && rotation < 45f) && animator.GetBool("runningClockwise") || (rotation > 135f && rotation < 225f) && !animator.GetBool("runningClockwise"))
            {
                chupaSprite.flipX = false;
                animator.Play("Base Layer.ChupaRunUp");
            }
            //running right
            else if ((rotation > 45f && rotation < 135f) && !animator.GetBool("runningClockwise") || (rotation > 225f && rotation < 315f) && animator.GetBool("runningClockwise"))
            {
                chupaSprite.flipX = false;
                animator.Play("Base Layer.ChupaLeftRightRun");
            }
            //running left
            else if ((rotation > 45f && rotation < 135f) && animator.GetBool("runningClockwise") || (rotation > 225f && rotation < 315f) && !animator.GetBool("runningClockwise"))
            {
                chupaSprite.flipX = true;
                animator.Play("Base Layer.ChupaLeftRightRun");
            }
        }
        //If chupa is pouncing, switch how the animations are called so it fits the chupa's movement
        else
        {
            //pouncing right
            if(rotation > 315f || rotation > 0f && rotation < 45f)
            {
                chupaSprite.flipX = false;
                animator.Play("Base Layer.ChupaLeftRightRun");
            }
            //pouncing up
            else if(rotation > 45f && rotation < 135f)
            {
                chupaSprite.flipX = false;
                animator.Play("Base Layer.ChupaRunUp");
            }
            //pouncing left
            else if(rotation > 135f && rotation < 225f)
            {
                chupaSprite.flipX = true;
                animator.Play("Base Layer.ChupaLeftRightRun");
            }
            //pouncing down
            else if(rotation > 225f && rotation < 315f)
            {
                chupaSprite.flipX = false;
                animator.Play("Base Layer.ChupaRunDown");
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
