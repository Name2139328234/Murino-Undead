using UnityEngine;



public class Movement : MonoBehaviour
{
	public float Speed
	{
		get
		{
			if (_isRunning)
				return _speed * _runMultiplier;
			else
				return _speed;
		}
	}

	public Vector2 Velocity
	{
		get
		{
			return _physics.velocity;
		}
	}

	[SerializeField]
	private Rigidbody2D _physics;
	[SerializeField]
	private float _runMultiplier;
	[SerializeField]
	private float _speed;

	private bool _isRunning;



	public void MoveLeft ()
	{
		transform.position -= new Vector3 (Speed * Time.deltaTime, 0, 0);
	}

	public void MoveRight ()
	{
		transform.position += new Vector3 (Speed * Time.deltaTime, 0, 0);
	}

	public void MoveUp ()
	{
		transform.position += new Vector3 (0, Speed * Time.deltaTime, 0);
	}

	public void MoveDown ()
	{
		transform.position -= new Vector3 (0, Speed * Time.deltaTime, 0);
	}

	public void Jump (float force)
	{
		_physics.AddForce (Vector2.up * force, ForceMode2D.Impulse);
	}

	public void StartRunning ()
	{
		_isRunning = true;
	}

	public void StopRunning ()
	{
		_isRunning = false;
	}
}
