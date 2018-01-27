using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put this on an empty game object and give feed 'pointPrefab' the prefab that you would like to spawn.
//when spawn is called it will instantiate that prefab at the origin point of the empty prefab
public class Spawner : MonoBehaviour {

    public Transform pointPrefab;


    public void Spawn()
    {
        Transform point = Instantiate(pointPrefab);

        //keep position of the spawner transform
        Vector3 position = Vector3.zero;
        //keep scale of 1 of the spawner transform
        Vector3 scale = Vector3.one;

        point.SetParent(transform, false);

    }
}
