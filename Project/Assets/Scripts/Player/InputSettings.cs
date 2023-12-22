using UnityEngine;



public class InputSettings : MonoBehaviour
{
	public KeyCode MoveLeft {get{return _moveLeft;}}
	public KeyCode MoveRight {get{return _moveRight;}}
	public KeyCode MoveUp {get{return _moveUp;}}
	public KeyCode MoveDown {get{return _moveDown;}}
	public KeyCode Run {get{return _run;}}
	public KeyCode Shoot {get{return _shoot;}}
	public KeyCode Ghost {get{return _ghost;}}
	public KeyCode Kick {get{return _kick;}}
	public KeyCode Hit {get{return _hit;}}
	public KeyCode Jump {get{return _jump;}}

	public KeyCode Interact {get{return _interact;}}

	[SerializeField]
	private KeyCode _moveLeft;
	[SerializeField]
	private KeyCode _moveRight;
	[SerializeField]
	private KeyCode _moveUp;
	[SerializeField]
	private KeyCode _moveDown;
	[SerializeField]
	private KeyCode _run;
	[SerializeField]
	private KeyCode _shoot;
	[SerializeField]
	private KeyCode _ghost;
	[SerializeField]
	private KeyCode _kick;
	[SerializeField]
	private KeyCode _hit;
	[SerializeField]
	private KeyCode _jump;
	[SerializeField]
	private KeyCode _interact;
}
