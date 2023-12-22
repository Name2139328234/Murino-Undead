using System;
using UnityEngine;
using UnityEngine.UI;



public class Interactable : MonoBehaviour
{
	public event EventHandler<EventArgs> OnInteracted;

	[SerializeField]
	private GameObject _interactionUI;



	public void Interact ()
	{
		if (OnInteracted != null)
			OnInteracted (this, new EventArgs ());
	}

	public void Enable ()
	{
		_interactionUI.SetActive (true);
	}

	public void Disable ()
	{
		_interactionUI.SetActive (false);
	}
}
