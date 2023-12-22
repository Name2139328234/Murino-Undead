using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SpeechNodeButton : Button
{
	public event EventHandler<EventArgs> OnClick;

	public SpeechNode Speech {get{return _speech;}}

	[SerializeField]
	private SpeechNode _speech;



	void Start ()
	{
		onClick.AddListener (Speak);
		onClick.AddListener (CallOnClick);
	}



	public void Initiate (SpeechNode speech)
	{
		_speech = speech;

		GetComponentInChildren<Text> ().text = speech.Content;
	}



	private void Speak ()
	{
		_speech.Speak ();
	}

	private void CallOnClick ()
	{
		if (OnClick != null)
			OnClick (this, new EventArgs ());
	}
}
