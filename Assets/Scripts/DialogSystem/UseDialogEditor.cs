using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEditor;

namespace DialogSystem
{
    [CustomEditor(typeof(UseDialog))]
    public class UseDialogEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            UseDialog ud = (UseDialog) target;
            DialogObject go = GameObject.FindWithTag("DialogsInspector").GetComponent<DialogsList>().dialogsList[ud.dialogId];
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
