using UnityEngine;



public class RefillOnSpeech : DialogueInteraction
{
	[SerializeField]
	private ResourceType _type;
	[SerializeField]
	private float _amount;//TODO unobvious behaviour in case of _type == Ammo



	protected override void TriggerInteraction (object sender, System.EventArgs e)
	{
		base.TriggerInteraction (sender, e);

		if (_type == ResourceType.Health)
			Player.Instance.Health.TakeHeal (_amount);

		if (_type == ResourceType.Ammo)
			Player.Instance.Shooting.AddAmmo ((int) _amount);
	}
}
