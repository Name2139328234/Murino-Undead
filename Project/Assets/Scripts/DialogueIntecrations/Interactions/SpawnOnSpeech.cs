using UnityEngine;



public class SpawnOnSpeech : DialogueInteraction
{
	[SerializeField]
	private GameObject _spawned;
	[SerializeField]
	private Transform[] _locations;



	protected override void TriggerInteraction (object sender, System.EventArgs e)
	{
		base.TriggerInteraction (sender, e);

		foreach (Transform location in _locations)
		{
			Instantiate (_spawned, location.position, location.rotation);
		}
	}
}
