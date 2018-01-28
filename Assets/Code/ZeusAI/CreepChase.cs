using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreepChase : NPCBaseFSM {

    [SerializeField]
    GameObject _destination;



    NavMeshAgent _navMeshAgent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _navMeshAgent = NPC.GetComponent<NavMeshAgent>();
        _destination = GameObject.FindWithTag("Destination");

        if (_navMeshAgent == null)
        {
            Debug.Log("The NavMeshAgent game component is not attached to " + NPC.gameObject.name);
        }
        else
        {
            SetDestination();
            _navMeshAgent.speed = agent_speed;
            _navMeshAgent.acceleration = agent_navigation;
        }
    }

    private void SetDestination()
    {
        
        if (_destination != null)
        {
            Debug.Log("here");
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //rotate character
    //    var direction = opponent.transform.position - NPC.transform.position;
    //    NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    //    //move character
    //    NPC.transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
