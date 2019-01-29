using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class play : MonoBehaviour {
	public GameObject next;
	public GameObject label;
	public void TaskOnClick()
	{
		
		SceneManager.LoadScene ("SceneTest");
	}
}
