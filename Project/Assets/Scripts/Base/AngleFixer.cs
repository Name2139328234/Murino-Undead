using UnityEngine;



public class AngleFixer : MonoBehaviour
{
	[SerializeField]
	private bool _x;
	[SerializeField]
	private bool _y;
	[SerializeField]
	private bool _z;
	
	private Vector3 _initialRotation;



	void Start ()
	{
		_initialRotation = transform.rotation.eulerAngles;
	}

	void Update ()
	{
		Vector3 _fixedRotation = transform.rotation.eulerAngles;

		if (_x)
			_fixedRotation.x = _initialRotation.x;
		if (_y)
			_fixedRotation.y = _initialRotation.y;
		if (_z)
			_fixedRotation.z = _initialRotation.z;

		transform.rotation = Quaternion.Euler (_fixedRotation);
	}
}
