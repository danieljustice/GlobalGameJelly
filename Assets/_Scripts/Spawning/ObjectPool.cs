using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
	List<PooledObject> availableObjects = new List<PooledObject> ();
	PooledObject prefab;

	public PooledObject GetObject()
	{
		PooledObject obj; 
		int lastAvailableIndex = availableObjects.Count - 1;
		if (lastAvailableIndex >= 0) {
			obj = availableObjects [lastAvailableIndex];
			availableObjects.RemoveAt (lastAvailableIndex);
			obj.gameObject.SetActive (true);
		} else {
			obj = Instantiate<PooledObject> (prefab);
			obj.transform.SetParent (transform, false);
			obj.Pool = this;
		}
		return obj;
	}

	public void AddObject(PooledObject obj)
	{
        if (obj.GetComponent<Rigidbody>())
        {
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        obj.transform.localRotation = Quaternion.identity;
        obj.gameObject.SetActive (false);
		availableObjects.Add (obj);
	}

	public static ObjectPool GetPool (PooledObject prefab)
	{
		GameObject obj;
		ObjectPool pool;
		if (Application.isEditor) {
			obj = GameObject.Find (prefab.name + " Pool");
			if (obj) {
				pool = obj.GetComponent<ObjectPool> ();
				if (pool)
					return pool;
			}
		}
		obj = new GameObject (prefab.name + " Pool");
		pool = obj.AddComponent<ObjectPool> ();
		pool.prefab = prefab;
		return pool;
	}

}
