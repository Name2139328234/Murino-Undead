using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueUI : Singleton<DialogueUI>
{
	[SerializeField]
	private Text _currentText;
	[SerializeField]
	private SpeechNodeButton _buttonTemplate;
	[SerializeField]
	private Transform _buttonListStart;
	[SerializeField]
	private float _buttonDistance;
	[SerializeField]
	private Image _background;

	private List<SpeechNodeButton> _currentButtons;



	void Start ()
	{
		_currentButtons = new List<SpeechNodeButton> ();
	}



	public void Initiate (SpeechNode node)
	{
		_currentText.text = node.Response;

		for (int i = 0; i < node.AvailableContinuations.Length; i++)
		{
			SpeechNodeButton button = Instantiate (_buttonTemplate, transform).GetComponent<SpeechNodeButton> ();

			button.Initiate (node.AvailableContinuations [i]);

			button.OnClick += CreateNewGeneration;

			button.transform.position = _buttonListStart.position + new Vector3 (0, _buttonDistance, 0) * i;

			_currentButtons.Add (button);
		}

		_background.enabled = true;
	}



	private void CreateNewGeneration (object sender, System.EventArgs e)
	{
		for (int i = _currentButtons.Count - 1; i >= 0; i--)
		{
			Destroy (_currentButtons [i].gameObject);
		}

		_currentButtons.Clear ();

		SpeechNodeButton senderButton = sender as SpeechNodeButton;



		_currentText.text = senderButton.Speech.Response;

		for (int i = 0; i < senderButton.Speech.AvailableContinuations.Length; i++)
		{
			SpeechNodeButton button = Instantiate (_buttonTemplate, transform).GetComponent<SpeechNodeButton> ();

			button.Initiate (senderButton.Speech.AvailableContinuations [i]);

			button.OnClick += CreateNewGeneration;

			button.transform.position = _buttonListStart.position + new Vector3 (0, _buttonDistance, 0) * i;

			_currentButtons.Add (button);
		}

		if (senderButton.Speech.AvailableContinuations.Length == 0)
			_background.enabled = false;
	}
}
