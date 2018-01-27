using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour {

    public GameObject goDropPrefab;
    public Transform dropPoint;
    public bool dropped = false;

    public void Drop()
    {
        if (dropped == false)
        {
            dropped = true;
            goDropPrefab = Instantiate(goDropPrefab, dropPoint.transform.position, dropPoint.transform.rotation);
        }
    }
}
