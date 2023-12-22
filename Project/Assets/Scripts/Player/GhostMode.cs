using System.Collections.Generic;
using UnityEngine;



public class GhostMode : MonoBehaviour
{
	[SerializeField]
	private Collider2D _playerCollider;
	[SerializeField]
	private Rigidbody2D _playerPhysics;
	[SerializeField]
	private GameObject[] _otherworldObjects;



	void Start ()
	{
		Disable ();
	}



	public void Enable ()
	{
		foreach (GameObject obj in _otherworldObjects)
			obj.SetActive (true);

		_playerCollider.enabled = false;
		_playerPhysics.isKinematic = true;

		_playerPhysics.velocity = new Vector2 (0, 0);
	}

	public void Disable ()
	{
		foreach (GameObject obj in _otherworldObjects)
			obj.SetActive (false);

		_playerCollider.enabled = true;
		_playerPhysics.isKinematic = false;

		_playerPhysics.velocity = new Vector2 (0, 0);
	}
}