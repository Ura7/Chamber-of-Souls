using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossWalkingState : StateMachineBehaviour
{
    NavMeshAgent boss;
    Transform player;

    int zar=0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zar = Random.Range(0,3);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        boss.SetDestination(player.position);
        float mesafe = Vector3.Distance(player.position, animator.transform.position);
        if(mesafe>20)
        {
            animator.SetBool("isLaying",true);
            animator.SetBool("isGetUp",false);
        }
        else if(mesafe<10)
        {
            animator.SetBool("isLaying",false);
        }
         if(mesafe<4f && zar==0)
        {
            animator.SetBool("isClaw",true);
            animator.SetTrigger("Start");
        }
        if(mesafe<4f && zar==2)
        {
            animator.SetBool("isSwing",true);
            animator.SetTrigger("Start");
        }

        else if(mesafe<4f && zar==1)
        {
            animator.SetBool("isJumpAttack",true);
            animator.SetTrigger("Start");
        }

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.SetDestination(animator.transform.position);
    }

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
