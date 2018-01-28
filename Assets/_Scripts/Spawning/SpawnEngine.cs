using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEngine : MonoBehaviour {

    public int startWait;

    public ScriptableStat waveNumber;

    public Vector2 batchrange = new Vector2(1,1);

    public float batchLull; // time between batches
    public float waveLull; // time between waves

    public PoolStuff[] creeps;

    private BoundedPoolSpawner bps;
    //public PoolStuff obj;

    public Transform destination;

    //private float batchTimer;
    //private float waveTimer;

    private void Start()
    {
        waveNumber.SetValue(0);
        //waveTimer = 0;
        //batchTimer = 0;
        bps = FindObjectOfType(typeof(BoundedPoolSpawner)) as BoundedPoolSpawner;

        StartCoroutine(MakeWaves());
    }

    IEnumerator MakeWaves()
    {
        yield return new WaitForSeconds(startWait); // wait before starting

        while (waveNumber.GetValue()<1f)
        {
            StartCoroutine(MakeBatches()); // 
            yield return new WaitForSeconds(waveLull);
        }
    }

    IEnumerator MakeBatches() 
    {
        PoolStuff[] newBatch = new PoolStuff[Mathf.RoundToInt(batchrange.y)];

        for (int i = 0; i < batchrange.y; i++)
        {
            newBatch[i] = creeps[Random.Range(0, creeps.Length)];
        }

        foreach (var item in newBatch)
        {
            PoolStuff obj2 = bps.SpawnObject(item);
        }

        yield return new WaitForSeconds(1);
    }
}
