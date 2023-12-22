using UnityEngine;



public class SpawnPoint : MonoBehaviour
{
	void Start ()
	{
		Player.Instance.transform.position = transform.position;
	}
}
