using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEngine : MonoBehaviour {

    public int batchsize;
    public float intervalStart;

    private BoundedPoolSpawner bps;
    public PoolStuff obj;

    public Transform destination;

    private float timer;

    private void Start()
    {
        bps = (BoundedPoolSpawner)GameObject.FindObjectOfType(typeof(BoundedPoolSpawner));
        timer = 0;
    }
    void Update () {

        if (timer > 0) 
        {
            timer -= Time.deltaTime;
        }
        else
        {
            PoolStuff[] batch = MakeBatch(batchsize);

            foreach (var item in batch)
            {
                PoolStuff obj2 = bps.SpawnObject(item);
            }
            timer = intervalStart;
        }
    }

    PoolStuff[] MakeBatch(int _batchsize)
    {
        PoolStuff[] newBatch = new PoolStuff[_batchsize];

        for (int i = 0; i < _batchsize; i++)
        {
            newBatch[i] = obj;
        }

        return newBatch;
    }
}
