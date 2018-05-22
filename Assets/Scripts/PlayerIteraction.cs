using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIteraction : MonoBehaviour {

    public float maxDistance = 10;
    public bool showHumaInteract;
    public GUIStyle boxStyle;
    public int curNPCId;

    void Start () {
        curNPCId = -1;
	}
	
	void Update () {

	}

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            if(hit.collider.gameObject.CompareTag("Human"))
            {
                showHumaInteract = true;
				if (Input.GetKeyDown (KeyCode.E)) {
                    curNPCId = hit.collider.gameObject.GetComponent<NPCScript>().npcId;
                    hit.collider.gameObject.GetComponent<DialogSystem.UseDialog> ().DoDialog = true;
				}
            }
            else
            {
                curNPCId = -1;
                showHumaInteract = false;
            }

        }
        else
        {
            showHumaInteract = false;
        }
    }

    void OnGUI()
    {
        if(showHumaInteract)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height - 100, 200, 50), "E", boxStyle);
        }
    }



}
