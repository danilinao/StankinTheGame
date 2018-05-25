using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace DialogSystem
{
    [System.Serializable]
    public class DialogsList : MonoBehaviour
    {
        [SerializeField] public List<DialogObject> dialogsList;
    }
}
