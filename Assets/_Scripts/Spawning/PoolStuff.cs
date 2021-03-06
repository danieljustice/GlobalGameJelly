﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PoolStuff : PooledObject {

	public Rigidbody Body { get; private set; }

	void Awake () {
		Body = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider enteredCollider)
	{
        if (enteredCollider.CompareTag("Enemy"))
        {
            ReturnToPool();
        }
	}

	void OnLevelWasLoaded() {
		ReturnToPool ();
	}
}