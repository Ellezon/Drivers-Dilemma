using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class next : MonoBehaviour {
	private bool ageset;
	private bool genderset;
	private bool nationalityset;
	private string age;
	private string gender;
	private string nationality;
	public Button error;

	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		error.gameObject.SetActive (true);
	}
	void Ageset(string value)
	{
		age = value;
		ageset = true;
	}
	void Genderset(string value)
	{
		if (value != "") {
			genderset = true;		
			gender = value;
		}
	}

	void Nationalityset(string value)
	{
		if (value != "") {
			nationalityset = true;
			nationality = value;
		}
	}

	void Update()
	{
		if (ageset && genderset && nationalityset) {
			this.gameObject.GetComponent<Button> ().interactable = true;
			error.gameObject.SetActive (false);
		} 
	}

	void TaskOnClick()
	{
		string url = "http://bugejamark.com/GameAI3/databaseInsertMenu.php";


		WWWForm form = new WWWForm();
		form.AddField("Gender", gender);
		form.AddField("Age", age);
		form.AddField ("Nationality",nationality);
		WWW www = new WWW (url, form);

		StartCoroutine(this.gameObject.GetComponent<POSTdata>().WaitForRequest(www));
		
	}


}
