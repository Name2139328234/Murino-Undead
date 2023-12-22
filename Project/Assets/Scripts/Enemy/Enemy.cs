using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private Health _health;
	[SerializeField]
	private Animator _animations;
	[SerializeField]
	private Shooting _ranged;
	[SerializeField]
	private Hit _melee;
	[SerializeField]
	private GameObject _drop;
	[SerializeField]
	private float _triggerRange;
	[SerializeField]
	private float _speed;
	[SerializeField]
	private bool _isAttackingGhost;



	void Start ()
	{
		_health.OnDie += SpawnPickUp;
		_health.OnDie += SelfDestruct;
	}

	void Update ()
	{
		if (Vector3.Distance (Player.Instance.transform.position, transform.position) < _triggerRange && (Player.Instance.IsGhost == false || _isAttackingGhost))
		{
			transform.position += (Player.Instance.transform.position - transform.position).normalized * _speed * Time.deltaTime;

			if (Player.Instance.transform.position.x - transform.position.x > 0)
				transform.rotation = Quaternion.Euler (0, 180, 0);
			else
				transform.rotation = Quaternion.Euler (0, 0, 0);

			_animations.SetBool ("isRunning", true);
		}
		else
			_animations.SetBool ("isRunning", false);



		Attack ();
	}



	private void Attack ()
	{
		if (Player.Instance.IsGhost && _isAttackingGhost == false)
		{
			_animations.SetBool ("isAttacking", true);

			return;
		}

		_animations.SetBool ("isAttacking", true);

		if (_ranged != null)
			_ranged.Act ();

		if (_melee != null)
			_melee.Act ();
	}

	private void SpawnPickUp (object sender, System.EventArgs e)
	{
		if (_drop == null)
			return;

		Instantiate (_drop, transform.position, transform.rotation);
	}

	private void SelfDestruct (object sender, System.EventArgs e)
	{
		Destroy (gameObject);
	}
}
