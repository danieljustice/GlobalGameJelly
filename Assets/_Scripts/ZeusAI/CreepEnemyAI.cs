using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepEnemyAI : MonoBehaviour {

    Animator anim;
    public GameObject target;

    public GameObject GetTarget()
    {
        return target;
    }

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("target");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("distance", Vector3.Distance(transform.position, target.transform.position));
	}

    void Attack()
    {
        //this is how you attack
    }

    public void StartAttack()
    {
        InvokeRepeating("Attack", .5f, 1.5f);
    }

    public void StopAttack()
    {
        CancelInvoke("Fire");
    }
}
