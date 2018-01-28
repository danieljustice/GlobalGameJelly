using UnityEngine;
public class Projectile : MonoBehaviour {    
    public ProjectileType projectileType;
    public int damage = 50;
    //public GameObject impactParticle;
    //public GameObject projectileParticle;
    //public GameObject muzzleParticle;
    //public GameObject[] trailParticles;
    //[HideInInspector]
    //public Vector3 impactNormal; //Used to rotate impactparticle.
    public float blastRadius;
    private bool hasCollided = false;

    void OnCollisionEnter(Collision hit)
    {
        Debug.Log("Hit Object: " + hit.gameObject.name);
        //if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "Projectile")
        //    return;

        if (!hasCollided)
        {
            hasCollided = true;
            switch (projectileType)
            {
                case ProjectileType.Precision:
                    if (hit.gameObject.tag == "Enemy") // Projectile will destroy objects tagged as Destructible
                    {
                        Debug.Log("Hit Object: " + hit.gameObject.name);
                        hit.gameObject.GetComponent<Health>().TakeDamage(damage);
                    }
                    break;
                case ProjectileType.Area:
                    ExplosionDamage();
                    break;

            }
            ////impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
            ////Debug.DrawRay(hit.contacts[0].point, hit.contacts[0].normal * 1, Color.yellow);
            ////yield WaitForSeconds (0.05);
            //foreach (GameObject trail in trailParticles)
            //{
            //    GameObject curTrail = transform.Find(projectileParticle.name + "/" + trail.name).gameObject;
            //    curTrail.transform.parent = null;
            //    Destroy(curTrail, 3f);
            //}
            ////transform.DetachChildren();
            //Destroy(projectileParticle, 3f);
            //Destroy(impactParticle, 4f);
            //Destroy(gameObject);
            ////projectileParticle.Stop();

            //ParticleSystem[] trails = GetComponentsInChildren<ParticleSystem>();
            ////Component at [0] is that of the parent i.e. this object (if there is any)
            //for (int i = 1; i < trails.Length; i++)
            //{
            //    ParticleSystem trail = trails[i];
            //    if (!trail.gameObject.name.Contains("Trail"))
            //        continue;

            //    trail.transform.SetParent(null);
            //    Destroy(trail.gameObject, 2);
            //}           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Object: " + other.gameObject.name);
        //if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "Projectile")
        //    return;

        if (!hasCollided)
        {
            hasCollided = true;
            switch (projectileType)
            {
                case ProjectileType.Precision:
                    if (other.gameObject.tag == "Enemy") // Projectile will destroy objects tagged as Destructible
                    {
                        Debug.Log("Hit Object: " + other.gameObject.name);
                        other.gameObject.GetComponent<Health>().TakeDamage(damage);
                    }
                    break;
                case ProjectileType.Area:
                    ExplosionDamage();
                    break;

            }
            ////impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
            ////Debug.DrawRay(hit.contacts[0].point, hit.contacts[0].normal * 1, Color.yellow);
            ////yield WaitForSeconds (0.05);
            //foreach (GameObject trail in trailParticles)
            //{
            //    GameObject curTrail = transform.Find(projectileParticle.name + "/" + trail.name).gameObject;
            //    curTrail.transform.parent = null;
            //    Destroy(curTrail, 3f);
            //}
            ////transform.DetachChildren();
            //Destroy(projectileParticle, 3f);
            //Destroy(impactParticle, 4f);
            //Destroy(gameObject);
            ////projectileParticle.Stop();

            //ParticleSystem[] trails = GetComponentsInChildren<ParticleSystem>();
            ////Component at [0] is that of the parent i.e. this object (if there is any)
            //for (int i = 1; i < trails.Length; i++)
            //{
            //    ParticleSystem trail = trails[i];
            //    if (!trail.gameObject.name.Contains("Trail"))
            //        continue;

            //    trail.transform.SetParent(null);
            //    Destroy(trail.gameObject, 2);
            //}           
        }
    }
    void ExplosionDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "Enemy") // Projectile will destroy objects tagged as Destructible
            {
                Debug.Log("Blast Hit " + hitColliders[i].gameObject.name);            
                //hitColliders[i].gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            i++;
        }
    }
}
