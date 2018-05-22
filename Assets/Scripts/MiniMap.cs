using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    public RenderTexture renderTexture;
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0,0,Screen.height / 3,Screen.height / 3));
        GUILayout.Box(renderTexture, GUILayout.Width(Screen.height / 3), GUILayout.Height(Screen.height / 3));
        GUILayout.EndArea();
    }
}
