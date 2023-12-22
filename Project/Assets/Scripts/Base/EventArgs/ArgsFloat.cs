using System;



public class ArgsFloat : EventArgs
{
	public float Value {get {return _value;}}

	private float _value;



	public ArgsFloat (float value)
	{
		_value = value;
	}
}
