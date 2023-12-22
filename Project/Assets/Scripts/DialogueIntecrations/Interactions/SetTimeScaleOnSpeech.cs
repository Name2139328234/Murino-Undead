using UnityEngine;



public class SetTimeScaleOnSpeech : DialogueInteraction
{
	[SerializeField]
	private float _scale;



	protected override void TriggerInteraction (object sender, System.EventArgs e)
	{
		base.TriggerInteraction (sender, e);

		Time.timeScale = _scale;
	}
}
