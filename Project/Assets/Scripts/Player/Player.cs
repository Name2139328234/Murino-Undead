using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player : Singleton<Player>
{
	public event EventHandler<EventArgs> OnGhost;
	public event EventHandler<EventArgs> OnHuman;

	public Health Health {get{return _health;}}
	public Shooting Shooting {get{return _shooting;}}
	public bool IsGhost {get{return _isGhost;}}

	[SerializeField]
	private Health _health;
	[SerializeField]
	private StringWrapper _respawSceneName;
	[SerializeField]
	private InputSettings _input;
	[SerializeField]
	private PlayerAnimation _animation;
	[SerializeField]
	private Movement _movement;
	[SerializeField]
	private Shooting _shooting;
	[SerializeField]
	private Transform _rotator;//questionable decision
	[SerializeField]
	private GhostMode _ghostMode;
	[SerializeField]
	private Kick _kick;
	[SerializeField]
	private Hit _hit;
	[SerializeField]
	private float _jumpForce;
	[SerializeField]
	private bool _isGhost;

	private List<Interactable> _inTriggerNow;



	void Start ()
	{
		DontDestroyOnLoad (gameObject);

		_inTriggerNow = new List<Interactable> ();

		_health.OnDie += Respawn;

		SceneManager.activeSceneChanged += ClearInteractableCache;
	}

	void Update ()
	{
		DoUniversalStuff ();

		if (_isGhost)
			DoGhostStuff ();
		else
			DoHumanStuff ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Interactable interactable = other.transform.root.GetComponentInChildren<Interactable> ();

		if (interactable == null)
			return;

		interactable.Enable ();
		_inTriggerNow.Add (interactable);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		Interactable interactable = other.transform.root.GetComponentInChildren<Interactable> ();

		if (interactable == null)
			return;
		
		interactable.Disable ();
		_inTriggerNow.Remove (interactable);
	}



	private void DoUniversalStuff ()
	{
		if (Input.GetKey (_input.MoveLeft))
		{
			_movement.MoveLeft ();

			_animation.TurnLeft ();

			_rotator.rotation = Quaternion.Euler (0, 180, 0);
		}

		if (Input.GetKey (_input.MoveRight))
		{
			_movement.MoveRight ();

			_animation.TurnRight ();

			_rotator.rotation = Quaternion.Euler (0, 0, 0);
		}

		if (Input.GetKey (_input.Run))
			_movement.StartRunning ();
		else
			_movement.StopRunning ();

		if (Input.GetKeyDown (_input.Ghost))
		{
			if (_isGhost)
			{
				_isGhost = false;

				_ghostMode.Disable ();

				if (OnHuman != null)
					OnHuman (this, new EventArgs ());
			}
			else
			{
				_isGhost = true;

				_ghostMode.Enable ();

				if (OnGhost != null)
					OnGhost (this, new EventArgs ());
			}
		}
	}

	private void DoGhostStuff ()
	{
		if (Input.GetKey (_input.MoveUp))
			_movement.MoveUp ();

		if (Input.GetKey (_input.MoveDown))
			_movement.MoveDown ();
	}

	private void DoHumanStuff ()
	{
		if (Input.GetKey (_input.Shoot))
		{
			_shooting.Act ();

			_animation.Shoot ();
		}

		if (Input.GetKeyDown (_input.Kick))
		{
			_kick.Act ();

			_animation.Kick ();
		}

		if (Input.GetKeyDown (_input.Hit))
		{
			_hit.Act ();

			_animation.Punch ();
		}

		if (Input.GetKeyDown (_input.Jump) && _movement.Velocity.y == 0)
		{
			_movement.Jump (_jumpForce);
		}

		if (Input.GetKeyDown (_input.Interact))
		{
			foreach (Interactable interactable in _inTriggerNow)
			{
				interactable.Interact ();
			}

			_animation.Interact ();
		}
	}

	private void ClearInteractableCache (Scene arg0, Scene arg1)
	{
		_inTriggerNow.Clear ();
	}

	private void Respawn (object sender, EventArgs e)
	{
		SceneManager.LoadScene (_respawSceneName.Content);

		_health.TakeHeal (_health.MaxValue);
	}
}
