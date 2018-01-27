using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEngine : MonoBehaviour {

    public float intervalStart;
    public BoundedPoolSpawner bps;
    public PoolStuff obj;
    public Transform destination;

    private float timer;

    private void Start()
    {
        timer = intervalStart;
    }
    void Update () {

        if (timer > 0) 
        {
            timer -= Time.deltaTime;
        }
        else
        {
            PoolStuff obj2 = bps.SpawnObject(obj);
            timer = intervalStart;
        }
    }
}
