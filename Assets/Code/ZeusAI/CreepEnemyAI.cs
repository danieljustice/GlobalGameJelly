﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepEnemyAI : MonoBehaviour {

    Animator anim;
    Animator childAnimator;
    public GameObject target;
    public PoolStuff poolStuff;
    public GameObject GetTarget()
    {
        return target;
    }

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("target");
        anim = GetComponent<Animator>();

        //this is horrible, requires atleast two anims on this object
        childAnimator = GetComponentsInChildren<Animator>()[1];
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("distance", Vector3.Distance(transform.position, target.transform.position));
		if(childAnimator)childAnimator.SetFloat("distance", Vector3.Distance(transform.position, target.transform.position));
    }

    void OnTriggerEnter(Collider other)
    {

        anim.SetBool("touchingTarget", true);
		if(childAnimator)childAnimator.SetBool("touchingTarget", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("touchingTarget", false);
		if(childAnimator)childAnimator.SetBool("touchingTarget", false);
    }


    void Attack()
    {
        //this is how you attack
        //print("attacking");
        //        transform.LookAt(target.transform);
        transform.localRotation = Quaternion.LookRotation(target.transform.position);
    }

    public void StartAttack()
    {
        InvokeRepeating("Attack", .5f, .1f);
    }

    public void StopAttack()
    {
        CancelInvoke("Fire");
    }

    public void Death()
    {
        //poolStuff.ReturnToPool();
        //do dieing things heres
        //anim.SetBool("isDead", true);
		if(childAnimator) childAnimator.SetBool("isDead", true);
    }
}
