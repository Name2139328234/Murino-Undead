using UnityEngine;
using UnityEngine.UI;



public class PlayerAnimation : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _active;
	[SerializeField]
	private ImageCycle _walkingLeftCycle;
	[SerializeField]
	private ImageCycle _walkingRightCycle;
	[SerializeField]
	private Sprite _ghostLeft;
	[SerializeField]
	private Sprite _ghostRight;
	[SerializeField]
	private Sprite _punchLeft;
	[SerializeField]
	private Sprite _punchRight;
	[SerializeField]
	private Sprite _kickLeft;
	[SerializeField]
	private Sprite _kickRight;
	[SerializeField]
	private Sprite _shootLeft;
	[SerializeField]
	private Sprite _shootRight;
	[SerializeField]
	private Sprite _interact;


	private bool _isLastTurnRight;


	void Start ()
	{
		_active.sprite = _walkingRightCycle.Cycle ();//TODO костыль

		Player.Instance.OnGhost += ImageToGhost;
		Player.Instance.OnHuman += ImageToHuman;

		_isLastTurnRight = true;
	}



	public void TurnLeft ()
	{
		if (Player.Instance.IsGhost != true)
			_active.sprite = _walkingLeftCycle.Cycle ();
		else
			_active.sprite = _ghostLeft;

		_isLastTurnRight = false;
	}

	public void TurnRight ()
	{
		if (Player.Instance.IsGhost != true)
			_active.sprite = _walkingRightCycle.Cycle ();
		else
			_active.sprite = _ghostRight;

		_isLastTurnRight = true;
	}

	public void Interact ()
	{
		_active.sprite = _interact;
	}

	public void Punch ()
	{
		if (_isLastTurnRight)
			_active.sprite = _punchRight;
		else
			_active.sprite = _punchLeft;
	}

	public void Kick ()
	{
		if (_isLastTurnRight)
			_active.sprite = _kickRight;
		else
			_active.sprite = _kickLeft;
	}

	public void Shoot ()
	{
		if (_isLastTurnRight)
			_active.sprite = _shootRight;
		else
			_active.sprite = _shootLeft;
	}



	private void ImageToGhost (object sender, System.EventArgs e)
	{
		if (_isLastTurnRight)
			_active.sprite = _ghostRight;
		else
			_active.sprite = _ghostLeft;
	}

	private void ImageToHuman (object sender, System.EventArgs e)
	{
		if (_isLastTurnRight)
			_active.sprite = _walkingRightCycle.Cycle ();
		else
			_active.sprite = _walkingLeftCycle.Cycle ();
	}
}
