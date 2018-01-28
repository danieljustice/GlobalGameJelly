﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEngine : MonoBehaviour {

    public int startWait; // wait before starting the waves
    public ScriptableBool wavesAreGo;
    public ScriptableStat waveNumber; // what wave are we on?

    // The two below are based on the waveNumber.
    public ScriptableStat batchModifier; // how much should we increase the number of batches?
    public ScriptableStat batchSizeModifier; // how much should we increase the number within a batch?

    public float batchLull; // time between batches
    public float waveLull; // time between waves

    public GameObject[] creeps;

    private BoundedSpawner bps;

    private void Start()
    {
        waveNumber.SetValue(0);
        wavesAreGo.SetValue(true);
        bps = FindObjectOfType(typeof(BoundedSpawner)) as BoundedSpawner;

        StartCoroutine(MakeWaves());
    }

    IEnumerator MakeWaves()
    {
        yield return new WaitForSeconds(startWait); // wait before starting

        while (wavesAreGo)
        {
            StartCoroutine(MakeBatches());
            yield return new WaitForSeconds(waveLull); // wait time between waves

            waveNumber.SetValue(1); // for now we can increase batches
        }
    }

    IEnumerator MakeBatches() 
    {
        for (int i = 0; i < Mathf.RoundToInt(waveNumber.GetValue() * batchModifier.GetValue()); i++)
        {
            int batchsize = Mathf.RoundToInt(waveNumber.GetValue() * batchSizeModifier.GetValue());
            GameObject[] newBatch = new GameObject[batchsize];

            for (int x = 0; x < batchsize; x++)
            {
                newBatch[x] = creeps[Random.Range(0, creeps.Length)];
            }

            foreach (var item in newBatch)
            {
                GameObject obj2 = bps.SpawnObject(item);
            }
        }

        yield return new WaitForSeconds(batchLull);
    }
}
