using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndClimb : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.9f)
        {
            PlayerConstructor.instance.DisableComponenets("isClimbing");
            PlayerConstructor.instance.DisableComponenets("isProClimbing");
            PlayerConstructor.instance.DefultIKElement();
        }
    }
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.SetBool("isClimbing", false);
    //    animator.gameObject.GetComponent<Rigidbody>().useGravity = true;
    //    animator.applyRootMotion = false;
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
