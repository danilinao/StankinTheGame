using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DialogSystem
{
    [CreateAssetMenu(fileName = "DialogObject", menuName = "Scriptable Objects/Dialog", order = 1)]
    public class DialogObject : ScriptableObject
    {
        public List<Node> _dialogs;
    }
}