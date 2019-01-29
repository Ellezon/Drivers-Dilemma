using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {

	GameObject levels;

	void Awake()
	{
		levels = GameObject.Find("LevelsList");
	}

	void OnTriggerEnter(Collider collide)
	{
		if ((collide.gameObject.tag == "Car") && (collide.GetType() == typeof(CapsuleCollider)))
		{
			StartCoroutine (GetRandomLevel());
		}
	}

	public IEnumerator GetRandomLevel() {

        yield return new WaitForSeconds(1.5f);

        float fadeTime = GameObject.Find("GameController").GetComponent<FadingScript> ().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);

		if (levels.GetComponent<LevelsList> ().levels.Count == 0) {
			for (int i = 1; i <= 10; i++) {
				levels.GetComponent<LevelsList>().levels.Add(i);
			}		
			SceneManager.LoadSceneAsync ("thank you");
		}
		else {			
			int randomIndex = Random.Range(0, levels.GetComponent<LevelsList>().levels.Count);
			int randomLevel = (int)levels.GetComponent<LevelsList>().levels[randomIndex];
			levels.GetComponent<LevelsList>().levels.RemoveAt(randomIndex);

			SceneManager.LoadSceneAsync("Scene" + randomLevel + ".1");
		}
	}
}
