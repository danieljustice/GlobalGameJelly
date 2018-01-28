using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {
    GameObject dropObject;
    public GameObject goDropPrefab;
    public Transform dropPoint;
    public bool dropped = false;

    // Use this for initialization
    void Start () {

        dropPoint = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Drop();
        }
	}

    public void Drop()
    {
        if (dropped == false)
        {
            dropped = true;
            goDropPrefab = Instantiate(goDropPrefab, dropPoint.transform.position, dropPoint.transform.rotation);
        }
    }
}
