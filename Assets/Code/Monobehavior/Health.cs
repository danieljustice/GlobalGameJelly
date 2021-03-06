﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour {

    //public AudioClip deathClip;                 // The sound to play when the enemy dies.
    Animator animator;                              // Reference to the animator.
    //AudioSource audio;                     // Reference to the audio source.   
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    NavMeshAgent agent;
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 0.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.

    bool isDead;                                // Whether the enemy is dead.
    float timer;
    bool sinking;


    void Awake()
    {
        // Setting up the references.
        animator = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        //capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        //agent = GetComponent<NavMeshAgent>();

        // Setting the current health when the enemy first spawns.
        //currentHealth = startingHealth;
    }
    private void Start()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(int amount)
    {
        //Debug.Log(gameObject.name + " Took Damage!");
        currentHealth -= amount;
        // If the enemy is dead...
        if (currentHealth <= 0)
        {
            //GetComponent<NavMeshAgent>().isStopped = true;
            Death();
            return;
        }
        // Play the hurt sound effect.
        //enemyAudio.Play();
        //animator.SetTrigger("Damage");
        //StartCoroutine(Hit());
    }



    void Death()
    {
        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
        //capsuleCollider.isTrigger = true;
        if (animator)
        {
            animator.SetBool("isDead", true);
        }
            //yield return new WaitForSecondsRealtime(2f);
        isDead = true;
    }
    IEnumerator Hit()
    {
        agent.isStopped = false;
        agent.destination = transform.position;
        yield return new WaitForSecondsRealtime(0.2f);

    }
}
