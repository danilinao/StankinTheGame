using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameRotation : MonoBehaviour {

    RaycastHit hit;


    void Start () {
		
	}
	
	void Update () {
        this.gameObject.transform.GetChild(0).transform.LookAt(GameObject.FindWithTag("Player").transform.position);
        this.gameObject.transform.GetChild(0).transform.Rotate(new Vector3(0, 180, 0));
        this.gameObject.transform.GetChild(1).transform.LookAt(GameObject.FindWithTag("Player").transform.position);
    }
}
