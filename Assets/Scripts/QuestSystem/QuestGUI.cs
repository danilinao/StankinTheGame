using UnityEngine;



public class QuestGUI : MonoBehaviour {

    public GUIStyle boxStyle;
    public GUIStyle questStyle;
    public GUIStyle headerStyle;
    public QuestList questsList;
    public bool lockCursor;
    public QuestHandler questHandler;

    
    void Start () {

        questsList = GameObject.Find("QuestInspector").GetComponent<QuestList>();
        lockCursor = true;
        headerStyle.fixedHeight = (Screen.height / 2)/10;
        questHandler = GetComponent<QuestHandler>();
    }

	void Update () {
		if(Input.GetKey(KeyCode.LeftControl))
        {
            FreezPlayer();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            UnFreezPlayer();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - Screen.width / 6 - 10,Screen.height/2 - Screen.height/4, Screen.width / 6, Screen.height / 2), boxStyle);
        GUILayout.Label("Quests",headerStyle);
        GUILayout.BeginArea(new Rect(0, (Screen.height / 2) / 10, Screen.width / 6,Screen.height / 2 - (Screen.height / 2)/10), questStyle);
        for(int i = 0; i < questHandler.currentQuests.Count; i++)
        {
            if(questsList.questsList[questHandler.currentQuests[i]].type == "positionQuest")
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(questsList.questsList[questHandler.currentQuests[i]].positionQuest.name + "\n");
                GUILayout.Toggle(questsList.questsList[questHandler.currentQuests[i]].complete,"");
                GUILayout.EndHorizontal();
                GUILayout.Label("--" + questsList.questsList[questHandler.currentQuests[i]].positionQuest.description + "\n");
            }
            else if (questsList.questsList[questHandler.currentQuests[i]].type == "talkQuest")
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(questsList.questsList[questHandler.currentQuests[i]].talkQuest.name + "\n");
                GUILayout.Toggle(questsList.questsList[questHandler.currentQuests[i]].complete, "");
                GUILayout.EndHorizontal();
                GUILayout.Label("--" + questsList.questsList[questHandler.currentQuests[i]].talkQuest.description + "\n");
            }
        }
        GUILayout.EndArea();
        GUILayout.EndArea();
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
