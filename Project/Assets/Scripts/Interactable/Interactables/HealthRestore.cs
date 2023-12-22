using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
	[SerializeField]
	private Interactable _healTrigger;
	[SerializeField]
	private float _healingAmount;



	void Start ()
	{
		_healTrigger.OnInteracted += RestorePlayerHealth;
	}

	void RestorePlayerHealth (object sender, System.EventArgs e)
	{
		Player.Instance.GetComponent<Health> ().TakeHeal (_healingAmount);
	}
}
