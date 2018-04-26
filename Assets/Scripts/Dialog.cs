using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
	[SerializeField]
	public int m_ID;
	[SerializeField]
	public string name;
	[SerializeField]
	public string keyText;
	[SerializeField]
	[TextArea(3,10)]
	public string fullText;
	[SerializeField]
	public List<int> answers;
}


[CreateAssetMenu(fileName="Dialog")]
[System.Serializable]
public class Dialog : ScriptableObject {	
	[SerializeField]
	[TextArea(3,10)]
	public string firstMessage;
	[SerializeField]
	public List<Node> nodes;
}
