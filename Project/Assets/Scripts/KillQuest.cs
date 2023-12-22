using System;
using UnityEngine;



public class KillQuest : MonoBehaviour
{
	public event EventHandler<EventArgs> OnCompleted;
	
	[SerializeField]
	private Health[] _targets;

	private int counter;



	void Start ()
	{
		counter = _targets.Length;

		foreach (Health target in _targets)
		{
			target.OnDie += UpdateCounter;
		}
	}

	void UpdateCounter (object sender, System.EventArgs e)
	{
		counter--;

		if (counter <= 0 && OnCompleted != null)
			OnCompleted (this, new EventArgs ());
	}
}
