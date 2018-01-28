using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZuesHandBaseFSM : StateMachineBehaviour {
    public GameObject zuesHand;
    public ChargeBoltBehavior chargedBolt;
    public float currentCharge;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        zuesHand = animator.gameObject;       
        chargedBolt = zuesHand.GetComponent<ChargeBoltBehavior>();
        //currentCharge = chargedBolt.chargeAmount;
    }
}
