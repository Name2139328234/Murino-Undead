using UnityEngine;



public class SetAvailableOnSpeech : DialogueInteraction
{
	[SerializeField]
	private SpeechNode _target;
	[SerializeField]
	private bool _value;


	protected override void TriggerInteraction (object sender, System.EventArgs e)
	{
		base.TriggerInteraction (sender, e);

		_target.IsAvailable = _value;
	}
}
