using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterScenarioTrigger : MonoBehaviour
{

	public GameObject buttonCanvas;
	public GameObject outLine;

	Button rightButton;
	Button leftButton;
	Button upButton;

	GameObject controller;
	GameObject sceneController;

	float timetaken;

	void Start ()
	{
		controller = GameObject.FindGameObjectWithTag ("GameController");
		sceneController = GameObject.Find ("SceneController");
		rightButton = GameObject.Find ("RightButton").GetComponent<Button> ();
		leftButton = GameObject.Find ("LeftButton").GetComponent<Button> ();
		upButton = GameObject.Find ("UpButton").GetComponent<Button> ();
		buttonCanvas.SetActive (false);
		outLine.SetActive (false);
	}

	void OnTriggerEnter (Collider collide)
	{
		//.Log ("enter");
		if ((collide.gameObject.tag == "Car") && (collide.GetType () == typeof(CapsuleCollider))) {
			Time.timeScale = 0.1F;
			collide.gameObject.GetComponent<DrivingScript> ().SetDriving (true);
			collide.gameObject.GetComponent<DrivingScript> ().IncrementIndex ();
			StartCoroutine (ShowCanvas (collide.gameObject));
		}

		if ((collide.gameObject.tag == "Car") && (collide.GetType () == typeof(BoxCollider))) {
			outLine.SetActive (true);
		}
	}

	public void DriveDirection (GameObject car, string direction, bool tookAction)
	{
		Time.timeScale = 1.0F;
		//.Log(direction);
		car.GetComponent<DrivingScript> ().SetDirection (direction);
		controller.GetComponent<GameController> ().StartTime (false);
		buttonCanvas.SetActive (false);

		timetaken = Mathf.Ceil ((3 - controller.GetComponent<GameController> ().getTime ()) * 100) / 100;

		int sceneNo = controller.GetComponent<GameController> ().getSceneNumber ();
		string kill_la;
		if (sceneNo == 1) {
			if (direction == "")
				kill_la = "yes";
			else
				kill_la = "no";
		} else if (sceneNo == 2) {
			if (direction == "Left")
				kill_la = "yes";
			else
				kill_la = "no";
		} else if (sceneNo == 6) {
			if (direction == "Right" || direction == "")
				kill_la = "yes";
			else
				kill_la = "no";
		} else
			kill_la = "null";

		string choice;
		if (direction == "Left")
        {
            controller.GetComponent<AudioSource>().Play();
            if (sceneNo == 10 || sceneNo == 8 || sceneNo == 9) {
				choice = "Self";
			} else {
				choice = sceneController.GetComponent<SceneController> ().leftDB;
			}
		} 

		else if (direction == "Right")
        {
            controller.GetComponent<AudioSource>().Play();
            choice = sceneController.GetComponent<SceneController> ().rightDB;
		} 

		else if (sceneNo == 10 || sceneNo ==9) {
			choice = "Car";
		} else if (sceneNo == 8) {
			choice = sceneController.GetComponent<SceneController> ().leftDB;
			controller.GetComponent<AudioSource> ().Play ();
		} else
			choice = "Self";

		controller.GetComponent<GameController>().SetTimeTaken (timetaken);
		controller.GetComponent<GameController>().SetActionTaken (tookAction);
		controller.GetComponent<GameController>().SetLawAbiding (kill_la);
		controller.GetComponent<GameController>().SetChoice (choice);
		controller.GetComponent<GameController>().SendChoice ();
	}

	IEnumerator ShowCanvas (GameObject car)
	{
		yield return new WaitForSeconds (0.05F);
		controller.GetComponent<GameController> ().StartTime (true);
		buttonCanvas.SetActive (true);
		leftButton.onClick.AddListener (() => DriveDirection (car, "Left", true));
		rightButton.onClick.AddListener (() => DriveDirection (car, "Right", true));
		upButton.onClick.AddListener (() => DriveDirection (car, "", true));
	}

}