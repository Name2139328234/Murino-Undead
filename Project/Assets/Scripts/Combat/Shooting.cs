using UnityEngine;



public class Shooting : Action
{
	[SerializeField]
	private Transform _shootPoint;
	[SerializeField]
	private Bullet _bullet;
	[SerializeField]
	private bool _IsUsingAmmo;
	[SerializeField]
	private int _ammo;

	private Timer _reloadTimer;
	private bool _isReloaded = true;



	protected override void Start ()
	{
		base.Start ();
	}

	public override void Act ()
	{
		if (!IsReady || (_IsUsingAmmo && _ammo == 0))
			return;

		base.Act ();

		Instantiate (_bullet, _shootPoint.position, Quaternion.Euler (0, 0, 0)/*TODO*/).GetComponent<Bullet> ().Initiate (_shootPoint.forward, _actorTeam);

		if (_IsUsingAmmo)
			_ammo--;
	}



	public void AddAmmo (int count)
	{
		_ammo += count;
	}
}
