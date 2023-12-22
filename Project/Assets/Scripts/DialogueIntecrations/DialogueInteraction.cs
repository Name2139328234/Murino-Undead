using UnityEngine;



public class DialogueInteraction : MonoBehaviour
{
	[SerializeField]
	private SpeechNode _trigger;



	void Start ()
	{
		_trigger.OnSpoken += TriggerInteraction;
	}



	protected virtual void TriggerInteraction (object sender, System.EventArgs e)
	{
		
	}
}
