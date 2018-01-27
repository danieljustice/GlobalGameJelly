using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {
    public GameObject NPC;
    public GameObject opponent;
    public float moveSpeed = 2.0f;
    public float rotationSpeed = 1.0f;
    public float waypointAccuracy = 3.0f;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<EnemyAI>().GetTarget();
    }
}
