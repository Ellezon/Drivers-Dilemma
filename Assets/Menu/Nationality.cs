using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Nationality : MonoBehaviour {
	public Dropdown myDropdown;
	private string selection;
	public GameObject nextbutton;

	void Start() {
		myDropdown.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(myDropdown);
		});
	}
	void Destroy() {
		myDropdown.onValueChanged.RemoveAllListeners();
	}

	private void myDropdownValueChangedHandler(Dropdown target) {
		selection = myDropdown.options[target.value].text;
		nextbutton.gameObject.GetComponent<next>().SendMessage("Nationalityset",selection);
	}

	public void SetDropdownIndex(int index) {
		myDropdown.value = index;
	}
		


}
