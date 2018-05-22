using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    [Serializable]
    public class Node
    {
        [SerializeField] public string ButtonName;
        [SerializeField] public string Text;
        [SerializeField] public Rect Window;
        [SerializeField] public int WindowId;
        [SerializeField] public List<int> Links;
        [SerializeField] public bool begin = false;
        [SerializeField] public int questId;
        [SerializeField] public bool giveQuest = false;

        public Node()
        {
        }
    }
}
