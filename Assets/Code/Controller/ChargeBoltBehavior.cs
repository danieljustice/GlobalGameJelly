using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBoltBehavior : MonoBehaviour {
    public Animator animator;
    public string tagToCharge;
    public Slider chargeSlider;
    public float chargeAmount;
    public GameObject chargedBoltGo;
    public GameObject drawPowerFX;
    public GameObject holdPowerFX;

    void Start () {       
        animator.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        chargeAmount = chargeSlider.value;
        animator.SetFloat("ChargeAmount", chargeAmount);
    }
    public void EnableDrawPowerEffect()
    {
        drawPowerFX.SetActive(true);
    }
    public void DisableDrawPowerEffect()
    {
        drawPowerFX.SetActive(false);
    }
    public void EnableHoldPowerEffect()
    {
        holdPowerFX.SetActive(true);
    }
    public void DisableHoldPowerEffect()
    {
        holdPowerFX.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals(tagToCharge))
        {
            Debug.Log("Charging Hands!");
            chargeSlider.value++;
        }
    }

}
