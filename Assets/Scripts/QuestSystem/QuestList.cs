using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;
using UnityEditor;
using System;

public enum questType
{
    PositionQuest,
    TalkQuest
};
public enum whatNext
{
    Nothing,
    Dialog,
    Quest
};

[System.Serializable]
public class QuestHolder 
{
    public bool canTakeAgain;
    public bool complete;
    public bool taken;
    public int progress;
    public questType type;
    public PositionQuestObject positionQuest;
    public TalkQuestObject talkQuest;
    public whatNext whatNext;
    public int nextDialog;
    public int nextQuest;



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
public class SkillGainLevelInspector : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty prop, GUIContent label)
    {
        
        SerializedProperty complete = prop.FindPropertyRelative("complete");
        SerializedProperty progress = prop.FindPropertyRelative("progress");
        SerializedProperty taken = prop.FindPropertyRelative("taken");
        SerializedProperty type = prop.FindPropertyRelative("type");
        SerializedProperty positionQuest = prop.FindPropertyRelative("positionQuest");
        SerializedProperty talkQuest = prop.FindPropertyRelative("talkQuest");
        SerializedProperty next = prop.FindPropertyRelative("whatNext");
        SerializedProperty nextDialog = prop.FindPropertyRelative("nextDialog");
        SerializedProperty nextQuest = prop.FindPropertyRelative("nextQuest");

        EditorGUI.indentLevel++;
        prop.isExpanded = EditorGUI.Foldout(new Rect(rect.x, rect.y, rect.width, 16), prop.isExpanded, "Item " + EditorGUI.indentLevel);
        if (prop.isExpanded)
        {
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 16, rect.width, 16), complete, new GUIContent("Complete: "));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 32, rect.width, 16), progress, new GUIContent("Progress: "));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 48, rect.width, 16), taken, new GUIContent("Taken: "));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 64, rect.width, 16), type, new GUIContent("Type: "));
            if ((questType)type.intValue == questType.PositionQuest)
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + 80, rect.width, 16), positionQuest, new GUIContent("Quest: "));
            else if ((questType)type.intValue == questType.TalkQuest)
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + 80, rect.width, 16), talkQuest, new GUIContent("Quest: "));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 96, rect.width, 16), next, new GUIContent("What Next: "));
            if ((whatNext)next.intValue == whatNext.Dialog)
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + 112, rect.width, 16), nextDialog, new GUIContent("DialogId: "));
            else if ((whatNext)next.intValue == whatNext.Quest)
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + 112, rect.width, 16), nextQuest, new GUIContent("QuestId: "));
        }
        EditorGUI.indentLevel--;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isExpanded)
            return 128;
        else
            return 16;
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
