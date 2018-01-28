using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public Spawner[] spawners;
    public SpawnFunctionName function;
    static SpawnFunction[] functions = { BasicSpawn };
    static IEnumerator coroutine;

    static public bool readyForSpawn = true;

    private SpawnFunction func;

    static private SpawnController instance;
    // Use this for initialization
	void Awake () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        func = functions[(int)function];
        func(spawners);
    }


    static private void BasicSpawn(Spawner[] spawners)
    {
        if (readyForSpawn) {
            coroutine = BasicSpawnerEnumerator(spawners);
            instance.StartCoroutine(coroutine);
            readyForSpawn = false;
        }
    }

    static IEnumerator BasicSpawnerEnumerator(Spawner[] spawners)
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].Spawn();
            yield return null;
        }
    }
}
