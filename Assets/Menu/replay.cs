using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour {

	public void TaskOnClick()
	{
		SceneManager.LoadScene("SceneTest");
	}
}
