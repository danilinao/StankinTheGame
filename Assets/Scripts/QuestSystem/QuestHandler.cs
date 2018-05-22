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
                currentQuests.RemoveAt(i);
                break;
            }
            if (questsList.questsList[currentQuests[i]].type == "positionQuest")
            {
                float distance = Vector3.Distance(player.transform.position, questsList.questsList[currentQuests[i]].positionQuest.position);
                if(distance < questsList.questsList[currentQuests[i]].positionQuest.radius)
                {
                    questsList.questsList[currentQuests[i]].complete = true;
                }
            }
            else if (questsList.questsList[currentQuests[i]].type == "talkQuest")
            {
                if(player.GetComponent<PlayerIteraction>().curNPCId == questsList.questsList[currentQuests[i]].talkQuest.npcId)
                {
                    questsList.questsList[currentQuests[i]].complete = true;
                }
            }
        }
    }


}
