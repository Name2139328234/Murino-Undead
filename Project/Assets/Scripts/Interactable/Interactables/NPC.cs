using UnityEngine;



public class NPC : MonoBehaviour 
{
	[SerializeField]
	private SpeechNode firstNode;
	[SerializeField]
	private Interactable _speechTrigger;



	void Start ()
	{
		_speechTrigger.OnInteracted += GenerateDialogue;
	}

	void GenerateDialogue (object sender, System.EventArgs e)
	{
		DialogueUI.Instance.Initiate (firstNode);

		firstNode.Speak ();
	}




}
