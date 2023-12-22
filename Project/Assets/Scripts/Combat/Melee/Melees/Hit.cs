using UnityEngine;



public class Hit : Melee
{
	[SerializeField]
	private float _damage;



	protected override void Start ()
	{
		base.Start ();
	}



	public override void Act ()
	{
		if (!IsReady)
			return;

		base.Act ();



		RaycastHit2D hit = Physics2D.Raycast (_hitDirection.position, _hitDirection.forward, _hitDistance);

		if (hit.collider == null)
			return;

		Health target = hit.collider.transform.root.GetComponentInChildren<Health> ();

		if (target != null && target.Team != _actorTeam)
			target.TakeDamage (_damage);
	}
}
