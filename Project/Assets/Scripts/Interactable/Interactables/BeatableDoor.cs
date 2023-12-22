using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatableDoor : MonoBehaviour
{
	[SerializeField]
	private Interactable _trigger;
	[SerializeField]
	private Shooting _doorLauncher;



	void Start ()
	{
		_trigger.OnInteracted += LaunchDoor;
	}



	private void LaunchDoor (object sender, System.EventArgs e)
	{
		_doorLauncher.Act ();

		_trigger.OnInteracted -= LaunchDoor;

		Destroy (gameObject);
	}
}
