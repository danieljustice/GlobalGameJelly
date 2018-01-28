using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleDamage : MonoBehaviour {

    public Health health;
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            health.TakeDamage(damage);
        }
    }
}
