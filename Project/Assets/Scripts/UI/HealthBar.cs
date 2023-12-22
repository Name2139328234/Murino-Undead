using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HealthBar : MonoBehaviour
{
	[SerializeField]
	private Health _health;
	[SerializeField]
	private GameObject _barValue;



	void Start ()
	{
		_health.OnChangeValue += UpdateHealthBar;
	}



	private void UpdateHealthBar (object sender, ArgsFloat e)
	{
		_barValue.transform.localScale = new Vector3 (_health.NormalizedValue, _barValue.transform.localScale.y, _barValue.transform.localScale.z);
	}
}
