using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEngine : MonoBehaviour {

    public int startWait;

    public ScriptableStat waveNumber;
    public ScriptableBool wavesAreGo;
    public int numberOfBatches;
    public Vector2 batchrange = new Vector2(1,1);

    public float batchLull; // time between batches
    public float waveLull; // time between waves

    public PoolStuff[] creeps;

    private BoundedPoolSpawner bps;

    public Transform destination;

    private void Start()
    {
        waveNumber.SetValue(0);
        wavesAreGo.SetValue(true);
        bps = FindObjectOfType(typeof(BoundedPoolSpawner)) as BoundedPoolSpawner;

        StartCoroutine(MakeWaves());
    }

    IEnumerator MakeWaves()
    {
        yield return new WaitForSeconds(startWait); // wait before starting

        while (wavesAreGo)
        {
            StartCoroutine(MakeBatches());
            yield return new WaitForSeconds(waveLull);
        }
    }

    IEnumerator MakeBatches() 
    {
        for (int i = 0; i < numberOfBatches; i++)
        {
            PoolStuff[] newBatch = new PoolStuff[Mathf.RoundToInt(batchrange.y)];

            for (int x = 0; x < batchrange.y; x++)
            {
                newBatch[x] = creeps[Random.Range(0, creeps.Length)];
            }

            foreach (var item in newBatch)
            {
                PoolStuff obj2 = bps.SpawnObject(item);
            }
        }

        yield return new WaitForSeconds(batchLull);
    }
}
