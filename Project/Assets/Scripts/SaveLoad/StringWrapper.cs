using UnityEngine;



//ASK
//This class exists in order to give an ability to rename all instances of one string with guarantee and speed from editor
//This is improtant for save/load system, and also makes it safer
[CreateAssetMenu(fileName = "String Wrapper", menuName = "Custom/ScriptableObject/String Wrapper")]
public class StringWrapper : ScriptableObject
{
	public string Content {get{return _content;}}

	[SerializeField]
	private string _content;
}
