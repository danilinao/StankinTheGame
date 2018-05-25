using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    public RenderTexture renderTexture;
    public GameObject mmCamera;
    
	void Start () {
        mmCamera = GameObject.Find("Minimap");
	}
	
	void Update () {
		
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0,0,Screen.height / 3,Screen.height / 3));
        GUILayout.BeginVertical();
        GUILayout.Box(renderTexture, GUILayout.Width(Screen.height / 3), GUILayout.Height(5* (Screen.height / 3) / 6));

        GUILayout.Space(-5f);
        GUILayout.BeginHorizontal();

        if(GUILayout.Button("-", GUILayout.Height((Screen.height / 3) / 6)))
        {
            if (mmCamera.transform.position.y < 90f)
                mmCamera.transform.position = new Vector3(mmCamera.transform.position.x, mmCamera.transform.position.y + 5, mmCamera.transform.position.z);
        }
        if(GUILayout.Button("+", GUILayout.Height((Screen.height / 3) / 6)))
        {
            if (mmCamera.transform.position.y > 20f)
                mmCamera.transform.position = new Vector3(mmCamera.transform.position.x, mmCamera.transform.position.y - 5, mmCamera.transform.position.z);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
