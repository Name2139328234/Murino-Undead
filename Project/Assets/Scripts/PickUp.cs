using UnityEngine;



public class PickUp : MonoBehaviour
{
	[SerializeField]
	private ResourceType _type;
	[SerializeField]
	private int _refillingAmount;



	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.transform.root.GetComponentInChildren<Player> () != null)
		{
			if (_type == ResourceType.Health)
				Player.Instance.Health.TakeHeal (_refillingAmount);

			if (_type == ResourceType.Ammo)
				Player.Instance.Shooting.AddAmmo (_refillingAmount);
		}
	}
}
