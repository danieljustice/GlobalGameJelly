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
    }

    public PoolStuff SpawnObject(PoolStuff obj)
    {
        if (_ok & obj != null)
        {
            Vector3 new_position = new Vector3(0, 0, 0);

            if (use_x)
            {
                new_position.x = Random.Range(-_spawnBounds.extents.x, _spawnBounds.extents.x) + transform.position.x;
            }
            else
            {
                new_position.x = transform.position.x;
            }

            if (use_y)
            {
                new_position.y = Random.Range(-_spawnBounds.extents.y, _spawnBounds.extents.y) + transform.position.y;
            }
            else
            {
                new_position.y = transform.position.y;
            }

            if (use_z)
            {
                new_position.z = Random.Range(-_spawnBounds.extents.z, _spawnBounds.extents.z) + transform.position.z;
            }
            else
            {
                new_position.z = transform.position.z;
            }

            //SPAWN OBJECT
            PoolStuff spawn = obj.GetPooledInstance<PoolStuff>();
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