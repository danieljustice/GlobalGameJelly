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

    private BoundedSpawner[] spawners;

    private void Start()
    {
        waveNumber.SetValue(0);
        wavesAreGo.SetValue(true);
        spawners = FindObjectsOfType<BoundedSpawner>() as BoundedSpawner[];

        if (spawners.Length < 1)
        {
            Debug.Log("There are no spawners for the SpawnEngine!!!");
        }
        else if (creeps.Length < 1)
        {
            Debug.Log("There are no creeps in the SpawnEngine!!!");
        }
        else
        {
            StartCoroutine(MakeWaves());
        }
    }

    IEnumerator MakeWaves()
    {
        yield return new WaitForSeconds(startWait); // wait before starting

        waveNumber.SetValue(1); // start the waves!

        while (wavesAreGo)
        {
            Debug.Log(waveNumber.GetValue());
            StartCoroutine(MakeBatches());
            yield return new WaitForSeconds(waveLull); // wait time between waves
            waveNumber.ApplyChange(1);
        }
    }

    IEnumerator MakeBatches() 
    {
        if (Mathf.RoundToInt(batchModifier.GetValue()) == 0 | (Mathf.RoundToInt(batchSizeModifier.GetValue()) == 0))
            Debug.Log("Your rounded BatchModifier or BatchSizeModifier is equal to zero and needs to be more than 0!!!");
        
        for (int i = 0; i < Mathf.RoundToInt(waveNumber.GetValue() * batchModifier.GetValue()); i++)
        {
            BoundedSpawner whichSpawner = spawners[Random.Range(0,spawners.Length)];

            int batchsize = Mathf.RoundToInt(waveNumber.GetValue() * batchSizeModifier.GetValue());

            GameObject[] newBatch = new GameObject[batchsize];

            for (int x = 0; x < batchsize; x++)
            {
                newBatch[x] = creeps[Random.Range(0, creeps.Length)];
            }

            foreach (var item in newBatch)
            {
                GameObject obj = whichSpawner.SpawnObject(item);
            }

            yield return new WaitForSeconds(batchLull);
        }
    }
}
