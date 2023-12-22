using System;
using System.Collections.Generic;
using UnityEngine;



public class SpeechNode : MonoBehaviour
{
	public event EventHandler<EventArgs> OnSpoken;

	public bool IsAvailable = true;

	public SpeechNode[] AvailableContinuations
	{
		get
		{
			List<SpeechNode> result = new List<SpeechNode> ();

			foreach (SpeechNode node in _continuations)
			{
				if (node.IsAvailable)
					result.Add (node);
			}

			return result.ToArray ();
		}
	}
	public string Content {get{return _content;}}
	public string Response {get{return _response;}}

	[SerializeField]
	private SpeechNode[] _continuations;
	[SerializeField]
	private string _content;
	[SerializeField]
	private string _response;



	public void Speak ()
	{
		if (OnSpoken != null)
			OnSpoken (this, new EventArgs ());
	}
}
