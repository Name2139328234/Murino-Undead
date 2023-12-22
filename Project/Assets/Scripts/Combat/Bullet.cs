using UnityEngine;



public class Bullet : MonoBehaviour
{
	[SerializeField]
	private float _damage;
	[SerializeField]
	private float _speed;
	[SerializeField]
	private float _lifeTime;

	private Vector3 _direction;
	private Timer _lifeTimer;
	private Team _shooter;



	void Start ()
	{
		_lifeTimer = Timer.New (_lifeTime, false);

		_lifeTimer.OnTimeRanOut += DestroySelf;
	}

	void Update ()
	{
		transform.position += _direction * _speed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Health health = other.GetComponent<Health> ();

		if (health != null && health.Team != _shooter)
			health.TakeDamage (_damage);

		_lifeTimer.OnTimeRanOut -= DestroySelf;

		Destroy (gameObject);
	}



	public void Initiate (Vector3 direction, Team shooter)
	{
		_direction = direction;
		_shooter = shooter;
	}



	private void DestroySelf (object sender, System.EventArgs e)
	{
		Destroy (gameObject);
	}
}
