using UnityEngine;



public abstract class Action : MonoBehaviour
{
	[SerializeField]
	protected Team _actorTeam;

	[SerializeField]
	private float _cooldown;

	protected bool IsReady {get{return _isReady;}}//TODO bad architecture. Every heir has to check this before calling the "Attack" function

	private Timer _cooldownTimer;
	private bool _isReady;



	protected virtual void Start ()
	{
		_cooldownTimer = Timer.New (_cooldown, true);
		_cooldownTimer.OnTimeRanOut += Reload;
		_isReady = true;
	}



	public virtual void Act ()
	{
		if (!_isReady)
			return;

		_isReady = false;
		_cooldownTimer.Play ();
	}



	private void Reload (object sender, System.EventArgs e)
	{
		_isReady = true;
		_cooldownTimer.Pause ();
	}
}
