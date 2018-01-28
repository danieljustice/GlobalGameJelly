using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedPoolSpawner : MonoBehaviour
{
    public bool use_x;
    public bool use_y;
    public bool use_z;

    BoxCollider collider;
    Bounds _spawnBounds;
    bool _ok;

    Vector3 myposition;
    Quaternion myrotation;


    void Start()
    {
        _ok = true;
        collider = GetComponent<BoxCollider>();

        if (collider == null)
        {
            Debug.LogError("No Box Collider attached to game object.");
            _ok = false;
        }
        else
            _spawnBounds = collider.bounds;

        myposition = transform.position;
        myrotation = transform.rotation;
    }

    public PoolStuff SpawnObject(PoolStuff obj)
    {
        if (_ok & obj != null)
        {
            Vector3 new_position = new Vector3(0, 0, 0);

            if (use_x)
            {
                new_position.x = Random.Range(-_spawnBounds.extents.x, _spawnBounds.extents.x) + myposition.x;
            }
            else
            {
                new_position.x = myposition.x;
            }

            if (use_y)
            {
                new_position.y = Random.Range(-_spawnBounds.extents.y, _spawnBounds.extents.y) + myposition.y;
            }
            else
            {
                new_position.y = myposition.y;
            }

            if (use_z)
            {
                new_position.z = Random.Range(-_spawnBounds.extents.z, _spawnBounds.extents.z) + myposition.z;
            }
            else
            {
                new_position.z = myposition.z;
            }

            //SPAWN OBJECT
            //PoolStuff spawn = Instantiate<PoolStuff>(obj, new_position, transform.rotation) as PoolStuff;
            PoolStuff spawn = obj.GetPooledInstance<PoolStuff>(new_position, myrotation);
            spawn.transform.position = new_position;

            return spawn;

        }
        else
        {
            Debug.Log("SpawnObject hit an error");
            return null;
        }
    }
}