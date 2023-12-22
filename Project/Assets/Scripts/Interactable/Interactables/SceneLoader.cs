using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	private Interactable _sceneLoadTrigger;
	[SerializeField]
	private StringWrapper _sceneName;



	void Start ()
	{
		_sceneLoadTrigger.OnInteracted += LoadScene;
	}

	void LoadScene (object sender, System.EventArgs e)
	{
		SceneManager.LoadScene (_sceneName.Content);

		//Player.Instance.transform.position = SpawnPoint.Instance.transform.position;
	}
}
