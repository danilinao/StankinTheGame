using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using QuestSystem;

namespace DialogSystem
{
    public class DialogCreateWindows : EditorWindow
    {
        private bool _initFlag;
        private int _choiceIndex;
        private int index;
        private Vector2 _WindowScrollPos = Vector2.zero;
        private Vector2 _TextScrollPos = Vector2.zero;

        public DialogObject DialogObject;
        public QuestList questsList;
        public List<Node> Dialogs;
        public List<Rect> Windows;
        public int FocusingID;

        private void Init()
        {
            
            questsList = GameObject.Find("QuestInspector").GetComponent<QuestList>();
            Dialogs = DialogObject._dialogs;
            Windows = new List<Rect>();
            for (int i = 0; i < Dialogs.Count; i++)
            {
                Windows.Add(Dialogs[i].Window);
            }
            EditorUtility.SetDirty(DialogObject);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }


        private void OnGUI()
        {
            GUI.skin.textField.wordWrap = true;
            GUILayout.Label(FocusingID.ToString());
            if (!_initFlag)
            {
                Init();
                _initFlag = true;
            }

            for (int i = 0; i < Dialogs.Count; i++)
            {
                Dialogs[i].Window = Windows[i];
                Dialogs[i].WindowId = i;
            }


            if (GUILayout.Button("Create window"))
            {
                Node tmp = new Node();
                tmp.Window = new Rect(100, 100, 100, 50);
                tmp.Links = new List<int>();
                Dialogs.Add(tmp);
                Windows.Add(tmp.Window);
            }

            if (Dialogs.Count > 0)
            {
                GUILayout.BeginArea(new Rect(0, 50, maxSize.x, maxSize.y - 50));
                GUILayout.BeginArea(new Rect(0, 0, 300, maxSize.y - 50));
                if (GUILayout.Button("Delete Window"))
                {

                    Windows.RemoveAt(FocusingID);
                    Dialogs.RemoveAt(FocusingID);
                    for (int i = 0; i < Dialogs.Count; i++)
                    {
                        if (Dialogs[i].Links != null)
                        {
                            for (int j = 0; j < Dialogs[i].Links.Count; j++)
                            {
                                if (Dialogs[i].Links[j] > FocusingID)
                                {
                                    Dialogs[i].Links[j]--;
                                }

                            }
                            for (int j = 0; j < Dialogs[i].Links.Count; j++)
                            {
                                if (Dialogs[i].Links[j] == FocusingID)
                                {
                                    Dialogs[i].Links.Remove(FocusingID);
                                }
                            }
                        }
                    }
                    FocusingID = 0;

                }
                if (Dialogs.Count > 0)
                {
                    
                    Dialogs[FocusingID].ButtonName = GUILayout.TextField(Dialogs[FocusingID].ButtonName);
                    _TextScrollPos = GUILayout.BeginScrollView(_TextScrollPos, GUILayout.Width(200), GUILayout.Height(200));
                    Dialogs[FocusingID].Text = EditorGUILayout.TextArea(Dialogs[FocusingID].Text, GUILayout.Height(1000));
                    GUILayout.EndScrollView();
                    Dialogs[FocusingID].begin = GUILayout.Toggle(Dialogs[FocusingID].begin, "Begin?");
                    if(Dialogs[FocusingID].giveQuest = GUILayout.Toggle(Dialogs[FocusingID].giveQuest, "Give quest?"))
                    {
                        
                        index = EditorGUILayout.Popup(index, new string[] { "Position Quest", "Talk Quest"});

                        if (index == 0)
                        {
                            questsList.questsList[Dialogs[FocusingID].questId].type = "positionQuest";
                            questsList.questsList[Dialogs[FocusingID].questId].positionQuest = (QuestSystem.PositionQuestObject)EditorGUILayout.ObjectField("Quest", questsList.questsList[Dialogs[FocusingID].questId].positionQuest, typeof(QuestSystem.PositionQuestObject),true);
                            questsList.questsList[Dialogs[FocusingID].questId].talkQuest = null;
                        }
                        else if(index == 1)
                        {
                            questsList.questsList[Dialogs[FocusingID].questId].type = "talkQuest";
                            questsList.questsList[Dialogs[FocusingID].questId].talkQuest = (QuestSystem.TalkQuestObject)EditorGUILayout.ObjectField("Quest", questsList.questsList[Dialogs[FocusingID].questId].talkQuest, typeof(QuestSystem.TalkQuestObject), true);
                            questsList.questsList[Dialogs[FocusingID].questId].positionQuest = null;
                        }
                    }
                    var _choices = new string[Windows.Count];
                    for (var i = 0; i < _choices.Length; i++)
                        _choices[i] = Dialogs[i].ButtonName + " (" + Dialogs[i].WindowId.ToString() + ")" ;
                    _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices);
                    if (GUILayout.Button("Add to answers"))
                    {
                        Dialogs[FocusingID].Links.Add(_choiceIndex);
                    }

                    GUILayout.Label("Answers:");
                    for (int i = 0; i < Dialogs[FocusingID].Links.Count; i++)
                    {
                        GUILayout.BeginHorizontal();
                        GUILayout.Label(Dialogs[Dialogs[FocusingID].Links[i]].ButtonName + " (" + Dialogs[Dialogs[FocusingID].Links[i]].WindowId.ToString() + ")");
                        if (GUILayout.Button("Delete from answers", GUILayout.MaxWidth(150)))
                        {
                            Dialogs[FocusingID].Links.Remove(i);
                        }
                        GUILayout.EndHorizontal();
                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
                    }



                    GUILayout.EndArea();


                    _WindowScrollPos = GUI.BeginScrollView(new Rect(300, 0, position.width - 300, position.height - 50),
                        _WindowScrollPos,
                        new Rect(0, 0, 1000, 1000));
                    EditorGUILayout.LabelField("", GUI.skin.verticalSlider, GUILayout.ExpandHeight(true));
                    Handles.BeginGUI();
                    for (int i = 0; i < Dialogs.Count; i++)
                    {
                        if (Dialogs[i].Links != null)
                        {
                            for (int j = 0; j < Dialogs[i].Links.Count; j++)
                            {
                                Handles.DrawLine(Windows[i].center, Windows[Dialogs[i].Links[j]].center);
                            }
                        }
                    }
                    Handles.EndGUI();

                    BeginWindows();
                    if (Windows.Count > 0)
                    {
                        for (int i = 0; i < Windows.Count; i++)
                        {
                            Windows[i] = GUI.Window(i, Windows[i], WindowFunction, Dialogs[i].ButtonName + " (" + Dialogs[i].WindowId + ")");
                        }
                    }


                    EndWindows();
                    GUI.EndScrollView();

                    GUILayout.EndArea();

                }
            }
        }

        private void WindowFunction(int windowID)
        {
            GUI.skin.label.wordWrap = true;
            GUI.Label(new Rect(0,15,100,50),Dialogs[windowID].Text);
            GUI.DragWindow();
            if (Event.current.GetTypeForControl(windowID) == EventType.Used)
            {
                if (windowID >= 0 && windowID < Windows.Count)
                    FocusingID = windowID;
            }
        }


    }
}