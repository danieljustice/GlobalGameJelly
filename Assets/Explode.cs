using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    private bool _ok = false;

    // Testing
    //private float countdown;
    //public int testValue;

    //private void Start()
    //{
    //    countdown = 5;
    //}

    //private void Update()
    //{
    //    countdown -= Time.deltaTime;

    //    if (countdown < 1)
    //    {
    //        Denonate(testValue, testValue);
    //    }
    //}

    public void Denonate(int radius, float degreeOfForce)
    {
        Debug.Log("Radius: " + radius + " Force: " + degreeOfForce);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody body = nearbyObject.GetComponent<Rigidbody>();

            if (body!=null && nearbyObject.CompareTag("Enemy"))
            {
                _ok = true;
            }
            else if (body == null && nearbyObject.CompareTag("Enemy"))
            {
                body = nearbyObject.gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
                _ok = true;
            }

            if (_ok)
            {
                if (body!=null)
                {
                    body.AddExplosionForce(degreeOfForce, transform.position, radius);
                } 
                else
                {
                    Debug.Log("Where did the body go? I want to explode it!");
                }
            }
        }
    }
}
