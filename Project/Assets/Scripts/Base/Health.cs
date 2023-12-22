using System;
using UnityEngine;



public class Health : MonoBehaviour
{
	public event EventHandler<ArgsFloat> OnTakeDamage;
	public event EventHandler<ArgsFloat> OnChangeValue;
	public event EventHandler<EventArgs> OnDie;

	public Team Team {get{return _team;}}
	public float Value {get{return _value;}}
	public float MaxValue {get{return _maxValue;}}
	public float NormalizedValue {get{return _value / _maxValue;}}

	[SerializeField]
	private Team _team;
	[SerializeField]
	private float _maxValue;

	private float _value;



	void Start ()
	{
		_value = _maxValue;

		if (OnChangeValue != null)
			OnChangeValue (this, new ArgsFloat (_value));
	}



	public void TakeDamage (float damage)
	{
		if (_value == 0)
			return;
		if (damage == 0)
			return;

		if (_value - damage < 0)
			damage = _value;

		_value -= damage;

		if (OnTakeDamage != null)
			OnTakeDamage (this, new ArgsFloat (damage));
		if (OnChangeValue != null)
			OnChangeValue (this, new ArgsFloat (-1 * damage));

		if (_value <= 0)
		{
			if (OnDie != null)
				OnDie (this, null);
		}
	}

	public void TakeHeal (float heal)
	{
		if (heal == 0) return;

		if (_value + heal > _maxValue)
			heal = _maxValue - _value;

		_value += heal;

		if (OnChangeValue != null)
			OnChangeValue (this, new ArgsFloat (heal));
	}
}
