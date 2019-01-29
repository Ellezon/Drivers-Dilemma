using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public GameObject timer;
	float time;
	bool startTime;
	GameObject scenarioTrigger;
	GameObject car;

	int sceneNumber;
	string choice;
	int timegiven = 3;
	float timetaken;
	bool tookaction;
	string lawabiding = null;

	void Start ()
	{
		time = 3;
		startTime = false;
		scenarioTrigger = GameObject.FindGameObjectWithTag("Slow");
		car = GameObject.FindGameObjectWithTag("Car");

		string scene = SceneManager.GetActiveScene().name;

		if (scene [6] != '.'){
			sceneNumber = int.Parse ("" + scene [5]+scene[6]);
		} else {
			sceneNumber = int.Parse ("" + scene [5]);
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (time <= 0.01 && startTime) {
			scenarioTrigger.GetComponent<EnterScenarioTrigger> ().DriveDirection (car, "", false);
		}
		else if (startTime) {
			time -= (1 * Time.deltaTime) / Time.timeScale;
			timer.GetComponent<Text>().text = (Mathf.Ceil(time*100)/100).ToString();
			if (time <= 1)
				timer.GetComponent<Text>().color = Color.red;
		}

		if (startTime) {
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
				scenarioTrigger.GetComponent<EnterScenarioTrigger>().DriveDirection(car, "", true);
			if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                scenarioTrigger.GetComponent<EnterScenarioTrigger>().DriveDirection(car, "Right", true);
			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
				scenarioTrigger.GetComponent<EnterScenarioTrigger>().DriveDirection(car, "Left", true);
		}
	}

	public void StartTime(bool st) {
		this.startTime = st;
	}

	public void SetChoice(string c)
	{
		if (c == "")
			choice = "Straight";
		else
			choice = c;
	}

	public void SetTimeTaken(float tt)
	{
		timetaken = tt;
	}

	public void SetActionTaken(bool at)
	{
		tookaction = at;
	}

	public void SetLawAbiding(string la)
	{
		lawabiding = la;
	}

	public float getTime()
	{
		return time;
	}

	public int getSceneNumber()
	{
		return sceneNumber;
	}

	public void SendChoice()
	{
		string url = "http://bugejamark.com/GameAI3/databaseInsertChoice.php";
		WWWForm form = new WWWForm();
		form.AddField("Choice", choice);
		form.AddField("Timetaken",timetaken.ToString());
		form.AddField("Scene",sceneNumber.ToString());
		form.AddField ("Timegiven",timegiven.ToString());
		if (lawabiding != "null") 
		{
			form.AddField ("Lawabiding", lawabiding);
		}
		form.AddField ("Tookaction",tookaction.ToString());
		WWW www = new WWW (url, form);

		StartCoroutine(this.gameObject.GetComponent<POSTDataGlobal>().WaitForRequest(www));
	}
}
