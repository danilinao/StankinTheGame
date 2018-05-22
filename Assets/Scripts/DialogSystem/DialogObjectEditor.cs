using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DialogSystem
{
    [CustomEditor(typeof(DialogObject))]
    public class DialogObjectEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DialogObject go = (DialogObject) target;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Open DialogObject Window"))
            {
                DialogCreateWindows window = (DialogCreateWindows) EditorWindow.GetWindow(typeof(DialogCreateWindows));
                window.DialogObject = go;
                window.Show();

            }

            GUILayout.EndHorizontal();


        }
    }
}
