using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    float süre ;
    List<Transform> duraklar = new List<Transform>();

    NavMeshAgent npc; 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.GetComponent<NavMeshAgent>();
        süre=0;
        GameObject dk = GameObject.FindGameObjectWithTag("Durak");
        foreach(Transform a in dk.transform)
        duraklar.Add(a);

        npc.SetDestination(duraklar[Random.Range(0,duraklar.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(npc.remainingDistance <= npc.stoppingDistance )
        {
             npc.SetDestination(duraklar[Random.Range(0,duraklar.Count)].position);
        }
        süre += Time.deltaTime;
        if(süre>5)
        {
            animator.SetBool("isPatrolling",false);
        }

       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       npc.SetDestination(npc.transform.position); 
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
