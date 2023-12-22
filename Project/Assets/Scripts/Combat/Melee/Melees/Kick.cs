using UnityEngine;



public class Kick : Melee
{
	[SerializeField]
	private float _strength;
	[SerializeField]
	[Range(0, 1)]
	private float _distanceStrengthFallof;



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

		Rigidbody2D target = hit.collider.transform.root.GetComponentInChildren<Rigidbody2D> ();

		if (target != null)
			target.AddForce (_hitDirection.forward * _strength * (1 - hit.fraction * _distanceStrengthFallof), ForceMode2D.Impulse);
	}
}
