using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{

    [CreateAssetMenu(fileName = "QuestObject", menuName = "Scriptable Objects/QuestObject/Position Quest", order = 1)]
    public class PositionQuestObject : ScriptableObject
    {
        [SerializeField] public string name;
        [SerializeField] public string description;
        [SerializeField] public Vector3 position;
        [SerializeField] public float radius;
    }

    [CreateAssetMenu(fileName = "QuestObject", menuName = "Scriptable Objects/QuestObject/Talk Quest", order = 2)]
    public class TalkQuestObject : ScriptableObject
    {
        [SerializeField] public string name;
        [SerializeField] public string description;
        [SerializeField] public int npcId;
    }
}
