using UnityEngine;
public class Projectile : MonoBehaviour {    
    public int damage = 50;
    public GameObject impactParticle;
    public float blastRadius;
    private bool hasCollided = false;
 
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            Debug.Log("Hit Object: " + other.gameObject.name);
            hasCollided = true;
            ExplosionDamage();           
            Destroy(gameObject,1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered Object: " + other.gameObject.name);

        if (other.gameObject.tag == "Terrain")
        {
            Debug.Log("Hit Object: " + other.gameObject.name);
            hasCollided = true;
            //GameObject projectileInstance = Instantiate(impactParticle);
            ExplosionDamage();                  
            ParticleSystem[] trails = GetComponentsInChildren<ParticleSystem>();
            //Component at [0] is that of the parent i.e. this object (if there is any)
            for (int i = 1; i < trails.Length; i++)
            {
                ParticleSystem trail = trails[i];
                if (!trail.gameObject.name.Contains("Trail"))
                    continue;
                trail.transform.SetParent(null);
                Destroy(trail.gameObject, 2);
            }
            Destroy(gameObject);
        }
    }
    private void ExplosionDamage()
    {
        GameObject projectileInstance = Instantiate(impactParticle, transform.position, transform.rotation);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);

        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "Enemy"|| hitColliders[i].gameObject.tag == "Friend") // Projectile will destroy objects tagged as Destructible
            {
                Debug.Log("Blast Hit " + hitColliders[i].gameObject.name);            
                hitColliders[i].gameObject.GetComponent<Health>().TakeDamage(damage);
            }
            i++;
        }
    }
}
