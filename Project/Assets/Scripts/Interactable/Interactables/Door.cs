using UnityEngine;



public class Door : MonoBehaviour
{
	[SerializeField]
	private Interactable _doorTrigger;
	[SerializeField]
	private Collider2D _door;
	[SerializeField]
	private SpriteRenderer _closedDoor;
	[SerializeField]
	private SpriteRenderer _openedDoor;



	void Start ()
	{
		_openedDoor.enabled = false;
		_closedDoor.enabled = true;

		_doorTrigger.OnInteracted += SetActives;
	}



	private void SetActives (object sender, System.EventArgs e)
	{
		_openedDoor.enabled = !_openedDoor.enabled;
		_closedDoor.enabled = !_closedDoor.enabled;

		_door.enabled = !_door.enabled;
	}
}
