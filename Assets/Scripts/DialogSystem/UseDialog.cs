﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class UseDialog : MonoBehaviour
    {

        public GameObject questInspector;
        private Vector2 _scrollPos = Vector2.zero;
        private Vector2 _scrollPos2 = Vector2.zero;
        public Material haveQuest;
        public Material canPassQuest;
        public QuestList questsList;

        public GUIStyle boxStyle;
        public GUIStyle textBoxStyle;
        public GUIStyle textLabelStyle;
        public GUIStyle answerBoxStyle;
        public DialogObject DialogObject;
        public bool DoDialog = false;
        [HideInInspector] public Node _tmp;

        void Start()
        {

            questsList = GameObject.Find("QuestInspector").GetComponent<QuestList>();
            ResetDialog();
            questInspector = GameObject.FindWithTag("QuestInspector");
            this.gameObject.transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material = null;
            for (int i = 0; i < DialogObject._dialogs.Count; i++)
            {
                if(questsList.questsList[DialogObject._dialogs[i].questId].positionQuest != null || questsList.questsList[DialogObject._dialogs[i].questId].talkQuest != null)
                {
                    this.gameObject.transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material = haveQuest;
                }
            }
        }

        private void Update()
        {
            bool quest = false;
            for (int i = 0; i < DialogObject._dialogs.Count; i++)
            {
                if (questsList.questsList[DialogObject._dialogs[i].questId].positionQuest != null || questsList.questsList[DialogObject._dialogs[i].questId].talkQuest != null)
                {
                    quest = true;
                    break;
                }
            }
            if(!quest)
            {
                this.gameObject.transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material = null;
            }
            else
            {
                this.gameObject.transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material = haveQuest;
            }
        }
        void OnGUI()
        {
            if (DoDialog)
            {

                FreezPlayer();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GUILayout.BeginArea(new Rect(Screen.width / 2 - (Screen.width / 3) / 2, Screen.height / 2 - (Screen.height * 3 / 4) / 2, Screen.width / 3, Screen.height * 3 / 4), boxStyle);
                GUILayout.BeginArea(new Rect(10,10, (Screen.width / 3) - 20, ((Screen.height * 3 / 4) / 2) - 20 ),"",textBoxStyle);                
                _scrollPos = GUILayout.BeginScrollView(_scrollPos, GUILayout.Width(Screen.width / 3), GUILayout.Height((Screen.height * 3 / 4) / 2));
                string text;
                if (_tmp.Text != "")
                    text = _tmp.Text;
                else
                    text = "Нам не о чем с тобой говорить.";
                GUILayout.Label(text, textLabelStyle);
                GUILayout.EndScrollView();
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(10, 10 + ((Screen.height * 3 / 4) / 2) - 20 + 10, (Screen.width / 3) - 20, ((Screen.height * 3 / 4) / 2) - 20),answerBoxStyle);

                _scrollPos2 = GUILayout.BeginScrollView(_scrollPos2, GUILayout.Width(Screen.width / 3 - 20) , GUILayout.Height((Screen.height * 3 / 4) / 2 - 20));
                for (int i = 0; i < _tmp.Links.Count; i++)
                {
                    GUIContent content = new GUIContent();
                    content.text = DialogObject._dialogs[_tmp.Links[i]].ButtonName;
                    if (GUILayout.Button(content))
                    {
                        if (questsList.questsList[DialogObject._dialogs[_tmp.Links[i]].questId].positionQuest != null || questsList.questsList[DialogObject._dialogs[_tmp.Links[i]].questId].talkQuest != null)
                        {
                            questInspector.GetComponent<QuestHandler>().currentQuests.Add(DialogObject._dialogs[_tmp.Links[i]].questId);
                        }
                        _tmp = DialogObject._dialogs[_tmp.Links[i]];
                    }

                }
                if (GUILayout.Button("Завершить диалог"))
                {
                    ResetDialog();
                }
                GUILayout.EndScrollView();

                GUILayout.EndArea();
                GUILayout.EndArea();
            }
        }

        void ResetDialog()
        {
            DoDialog = false;
            UnFreezPlayer();
            for (int i = 0; i < DialogObject._dialogs.Count; i++)
            {
                if (DialogObject._dialogs[i].begin)
                {
                    _tmp = DialogObject._dialogs[i];
                }
            }
        }
        void FreezPlayer()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponentInChildren<PlayerLook>().enabled = false;
            player.GetComponentInChildren<Animator>().enabled = false;
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<PlayerIteraction>().enabled = false;
        }

        void UnFreezPlayer()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponentInChildren<PlayerLook>().enabled = true;
            player.GetComponentInChildren<Animator>().enabled = true;
            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<PlayerIteraction>().enabled = true;
        }
    }
}