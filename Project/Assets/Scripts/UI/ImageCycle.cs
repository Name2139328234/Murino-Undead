using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ImageCycle : MonoBehaviour
{
	[SerializeField]
	private Sprite[] _cycle;

	private int current;



	void Start ()
	{
		current = 0;
	}

	public Sprite Cycle ()
	{
		current++;

		if (current >= _cycle.Length)
			current = 0;
		
		return _cycle [current];
	}
}
