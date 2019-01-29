using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReplayScript : MonoBehaviour {

	public Button replay;
	GameObject levels;

	// Use this for initialization
	void Start () {
		levels = GameObject.Find("LevelsList");
		replay.onClick.AddListener(() => Replay());
	}
	
	private IEnumerator Replay() {
		
		int randomIndex = Random.Range(0, 9);
		int randomLevel = (int)levels.GetComponent<LevelsList>().levels[randomIndex];
		levels.GetComponent<LevelsList>().levels.RemoveAt(randomIndex);

		yield return new WaitForSeconds(1.5f);

		float fadeTime = GameObject.Find("GameController").GetComponent<FadingScript>().BeginFade(1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadSceneAsync("Scene" + randomLevel + ".1");
	}
}
