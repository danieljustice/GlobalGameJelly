using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerlessStateR : StateMachineBehaviour {

    public ChargeBoltBehavior chargedBolt;
    public float currentCharge;
    public string tagToCharge;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        chargedBolt = animator.GetComponent<ChargeBoltBehavior>();
        chargedBolt.charging = false;      
        //chargedBolt.DisableDrawPowerEffect();
        //chargedBolt.DisableHoldPowerEffect();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Charging", chargedBolt.charging);
        //animator.SetFloat("CurrentCharge", chargedBolt.chargeAmount);       
        Debug.Log("Current Charge " + animator.GetFloat("CurrentCharge"));
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
