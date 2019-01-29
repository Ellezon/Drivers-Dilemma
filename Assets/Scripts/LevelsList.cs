using UnityEngine;
using System.Collections;

public class LevelsList : MonoBehaviour {

	public ArrayList levels = new ArrayList();

	void Awake() {
		DontDestroyOnLoad(this.gameObject);
		ResetLevels();
	}

	public void ResetLevels() {
		for (int i = 1; i <= 10; i++) {
			levels.Add(i);
		}
	}

		
}
