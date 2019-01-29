using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Age : MonoBehaviour {
	public InputField input;
	private string selection;
	public GameObject nextbutton;

	void Start() {
		input.onEndEdit.AddListener(delegate {
			myDropdownValueChangedHandler(input);
		});
	}
	void Destroy() {
		input.onValueChanged.RemoveAllListeners();
	}

	private void myDropdownValueChangedHandler(InputField target) {
		selection = input.text;
		if(selection.Length > 0)
		{
			nextbutton.gameObject.GetComponent<next>().SendMessage("Ageset",selection);
		}
	}


}
