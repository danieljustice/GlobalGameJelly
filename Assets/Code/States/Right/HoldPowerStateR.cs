using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPowerStateR : StateMachineBehaviour {
    public ChargeBoltBehavior chargedBolt;
    public float currentCharge;
    public string tagToCharge;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        chargedBolt = animator.GetComponent<ChargeBoltBehavior>();
        currentCharge = animator.GetFloat("CurrentCharge");
        Debug.Log("HoldPower State");
        chargedBolt.EnableReadyBoltEffect();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetFloat("CurrentCharge", chargedBolt.chargeAmount);
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Released Right Trigger");
            chargedBolt.EnableReadyBoltEffect();
            chargedBolt.chargeSlider.value = 0;
            animator.SetBool("ReadyFire", false);        
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        chargedBolt.DisableHoldPowerEffect();
    }
}
