using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInspector : MonoBehaviour {

    public Texture2D cross;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width/2 - Screen.width/60, Screen.height/2 - Screen.width / 60, Screen.width / 30, Screen.width / 30), cross);
    }
}
