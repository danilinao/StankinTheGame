using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameRotation : MonoBehaviour {

    RaycastHit hit;


    void Start () {
		
	}
	
	void Update () {
        transform.Find("Name").transform.LookAt(GameObject.FindWithTag("Player").transform.position);
        transform.Find("Name").transform.Rotate(new Vector3(0, 180, 0));
    }
}
