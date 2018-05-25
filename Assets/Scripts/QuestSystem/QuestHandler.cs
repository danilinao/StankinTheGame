using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class QuestHandler : MonoBehaviour {

    public GameObject player;
    public List<int> currentQuests;
    public QuestList questsList;

    void Start () {
        player = GameObject.FindWithTag("Player");
        questsList = GetComponent<QuestList>();
    }
	
	void Update () {

        for (int i = 0; i < currentQuests.Count; i++)
        {
            if (questsList.questsList[currentQuests[i]].complete)
            {
                if (questsList.questsList[currentQuests[i]].whatNext == whatNext.Dialog)
                {

                }
                else if (questsList.questsList[currentQuests[i]].whatNext == whatNext.Quest)
                {
                    currentQuests[i] = questsList.questsList[currentQuests[i]].nextQuest;
                }
                else
                {
                    currentQuests.RemoveAt(i);
                }
                break;
            }
            if (questsList.questsList[currentQuests[i]].type == questType.PositionQuest)
            {
                if(!GameObject.Find("QuestHandler"+ currentQuests[i]))
                {
                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    go.name = "QuestHandler" + currentQuests[i];
                    go.transform.position = questsList.questsList[currentQuests[i]].positionQuest.position;
                    go.transform.Rotate(new Vector3(90,0,0));
                    go.transform.localScale = new Vector3(questsList.questsList[currentQuests[i]].positionQuest.radius * 2, questsList.questsList[currentQuests[i]].positionQuest.radius * 2, 1);
                    go.layer = LayerMask.NameToLayer("MiniMap");
                    go.GetComponent<MeshRenderer>().material = Resources.Load("Materials/MMIcons/RoundArea", typeof(Material)) as Material;
                    go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    Destroy(go.GetComponent<MeshCollider>());
                }

                float distance = Vector3.Distance(player.transform.position, questsList.questsList[currentQuests[i]].positionQuest.position);
                if(distance < questsList.questsList[currentQuests[i]].positionQuest.radius)
                {
                    Destroy(GameObject.Find("QuestHandler" + currentQuests[i]));
                    questsList.questsList[currentQuests[i]].complete = true;
                }
            }
            else if (questsList.questsList[currentQuests[i]].type == questType.TalkQuest)
            {
                if(player.GetComponent<PlayerIteraction>().curNPCId == questsList.questsList[currentQuests[i]].talkQuest.npcId)
                {
                    questsList.questsList[currentQuests[i]].complete = true;
                }
            }
        }
    }


}
