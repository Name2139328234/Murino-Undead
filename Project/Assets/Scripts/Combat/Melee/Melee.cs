using UnityEngine;



public abstract class Melee : Action //TODO combine parts with playermelee and inherit the difference
{
	[SerializeField]
	protected Transform _hitDirection;
	[SerializeField]
	protected float _hitDistance;


	protected override void Start ()
	{
		base.Start ();
	}



	public override void Act ()
	{
		if (!IsReady)
			return;

		base.Act ();
	}
}
