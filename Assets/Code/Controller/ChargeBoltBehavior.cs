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
    
	void Start () {       
        animator.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        chargeAmount = chargeSlider.value;      	
	}
    public void ShowCharged()
    {
        chargedBoltGo.SetActive(true);
    }
    public void HideCharged()
    {
        chargedBoltGo.SetActive(false);
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
