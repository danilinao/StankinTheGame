using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDialog : MonoBehaviour
{

	public Dialog dialog;
	public int curDialogId;
	public bool showDialog;

	void Start ()
	{
		curDialogId = -1;
		showDialog = false;
	}

	void Update ()
	{
		
	}

	void OnGUI ()
	{
		if (showDialog) {
			FreezPlayer ();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			string curText;
			if (curDialogId == -1) {
				curText = dialog.firstMessage;
			} else {
				curText = dialog.nodes [curDialogId].fullText;
			}
			GUI.BeginGroup (new Rect (Screen.width / 2 - (Screen.width/3)/2, Screen.height / 2 - (Screen.height*3/4)/2, Screen.width/3, Screen.height*3/4));
			GUI.Box (new Rect (0, 0, Screen.width/3, Screen.height*3/4), "");
			GUI.TextArea (new Rect (0, 0, Screen.width/3, (Screen.height*3/4)/2), curText);

			Vector2 scrollPosition = Vector2.zero;
			GUI.BeginScrollView (new Rect (0, (Screen.height*3/4)/2, Screen.width/3, (Screen.height*3/4)/2), scrollPosition, new Rect (0, 0, Screen.width/3, (Screen.height*3/4)/2));
			if (curDialogId != -1) {
				int i = 0;
				for (i = 0; i < dialog.nodes [curDialogId].answers.Capacity; i++) {
					if (GUI.Button (new Rect (0, i * 35, Screen.width/3, 35), dialog.nodes [dialog.nodes [curDialogId].answers [i]].keyText)) {
						if (dialog.nodes [dialog.nodes [curDialogId].answers [i]].answers.Capacity > 0)
							curDialogId = dialog.nodes [dialog.nodes [curDialogId].answers [i]].m_ID;
						else {
							if (dialog.nodes [dialog.nodes [curDialogId].answers [i]].fullText != "") {
								if (GUI.Button (new Rect (0, i * 35, Screen.width/3, 35), dialog.nodes [dialog.nodes [curDialogId].answers [i]].keyText)) {
									curDialogId = dialog.nodes [dialog.nodes [curDialogId].answers [i]].m_ID;
								}
							} else {
								
								showDialog = false;
								UnFreezPlayer ();
								curDialogId = -1;
							}
						}
					}
				}
				if (GUI.Button (new Rect (0, (i) * 35, Screen.width/3, 35), "Окончить диалог")) {
					showDialog = false;
					UnFreezPlayer ();
					curDialogId = -1;
				}
			} else {
				int i = 0;
				for (i = 0; i < dialog.nodes.Capacity; i++) {
					if (GUI.Button (new Rect (0, i * 35, Screen.width/3, 35), dialog.nodes [i].keyText)) {
						if (dialog.nodes [i].answers.Capacity > 0)
							curDialogId = dialog.nodes [i].m_ID;
						else {
							if (dialog.nodes [i].fullText != "") {
								curDialogId = dialog.nodes [i].m_ID;
							} else {
								showDialog = false;
								UnFreezPlayer ();
								curDialogId = -1;
							}
						}
					}
				}
				if (GUI.Button (new Rect (0, (i) * 35, Screen.width/3, 35), "Окончить диалог")) {
					showDialog = false;
					UnFreezPlayer ();
					curDialogId = -1;
				}
			}

			GUI.EndScrollView ();
			GUI.EndGroup ();
		}
	}


	void FreezPlayer ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponentInChildren<PlayerLook> ().enabled = false;
		player.GetComponentInChildren<Animator> ().enabled = false;
		player.GetComponent<PlayerMove> ().enabled = false;
		player.GetComponent<PlayerIteraction> ().enabled = false;
	}

	void UnFreezPlayer ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponentInChildren<PlayerLook> ().enabled = true;
		player.GetComponentInChildren<Animator> ().enabled = true;
		player.GetComponent<PlayerMove> ().enabled = true;
		player.GetComponent<PlayerIteraction> ().enabled = true;
	}
}
