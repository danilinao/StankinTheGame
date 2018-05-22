using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;
using UnityEditor;
using System;

[System.Serializable]
public class QuestHolder
{
    public bool complete;
    public bool taken;
    public int progress;
    public string type;
    public PositionQuestObject positionQuest;
    public TalkQuestObject talkQuest;

    public QuestHolder()
    {

    }

    public QuestHolder copy()
    {
        QuestHolder copy = new QuestHolder();
        copy.complete = this.complete;
        copy.progress = this.progress;
        copy.taken = this.taken;
        copy.type = this.type;
        copy.positionQuest = this.positionQuest;
        copy.talkQuest = this.talkQuest;
        return copy;
    }

}

[CustomPropertyDrawer(typeof(QuestHolder))]
public class QuestHolderDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(new Rect(position.x, position.y, 10 , position.height), property.FindPropertyRelative("complete"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(position.x + 15, position.y, 10 , position.height), property.FindPropertyRelative("taken"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(position.x + 30, position.y, 30 , position.height), property.FindPropertyRelative("progress"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(position.x + 65, position.y, 100, position.height), property.FindPropertyRelative("type"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(position.x + 170, position.y, 150, position.height), property.FindPropertyRelative("positionQuest"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(position.x + 325, position.y, 150, position.height), property.FindPropertyRelative("talkQuest"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}

[Serializable]
public class QuestList : MonoBehaviour {

    [SerializeField] public List<QuestHolder> questsList;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
