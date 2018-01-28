using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerlessStateL : StateMachineBehaviour {
    public GameObject zuesHand;
    public ChargeBoltBehavior chargedBolt;
    public float currentCharge;
    public string tagToCharge;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        zuesHand = animator.gameObject;
        chargedBolt = zuesHand.GetComponent<ChargeBoltBehavior>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentCharge = chargedBolt.chargeAmount;
        animator.SetFloat("CurrentCharge", chargedBolt.chargeAmount);
        animator.GetFloat("CurrentCharge");
        Debug.Log("Current Charge " + animator.GetFloat("CurrentCharge"));

        if (chargedBolt.chargeAmount > 10)
        {
            Debug.Log("Fully Charged");

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Debug.Log("Holding Left Trigger");
                animator.SetBool("ReadyFire", true);
            }
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Debug.Log("Holding Right Trigger");
                animator.SetBool("ReadyFire", true);
            }


        }
    }
}
