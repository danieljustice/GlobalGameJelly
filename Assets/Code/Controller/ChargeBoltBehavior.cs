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
    public bool charging;
    public Transform firePoint;
    public float launchForce = 100f;
    void Start () {  
        animator.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        chargeAmount = chargeSlider.value;
        animator.SetFloat("CurrentCharge", chargeAmount);
        if (chargeAmount > 0)
            EnableHoldPowerEffect();
        else
            DisableHoldPowerEffect();


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
    public void FireBolt()
    {
        GameObject projectileInstance = Instantiate(chargedBoltGo, firePoint.position, firePoint.rotation);
        projectileInstance.GetComponent<Rigidbody>().velocity = launchForce * firePoint.forward;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals(tagToCharge))
        {
            Debug.Log("Charging Hands!");
            charging = true;
            EnableDrawPowerEffect();
            chargeSlider.value++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Stop Charging Hands!");
        charging = false;
        DisableDrawPowerEffect();
        //chargeSlider.value++;
        
    }

}
