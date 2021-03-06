﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepPatrol : NPCBaseFSM {

    GameObject[] waypoints;
    int currentWP;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");    
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            ////if no waypoints, do nothing
            //if (waypoints.Length == 0) return;
            ////if close enough to waypoint, move on to the next waypoint
            //if (Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < waypointAccuracy)
            //{
            //    currentWP = (currentWP + 1) % waypoints.Length;
            //}

            ////rotate towards target
            //var direction = waypoints[currentWP].transform.position - NPC.transform.position;
            //NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            ////move forwards (not necessarily towards target because of the rotation)
            //NPC.transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
