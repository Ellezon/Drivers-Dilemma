using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public GameObject left;
    public GameObject right;

    public GameObject boy;
    public GameObject girl;
    public GameObject man;
    public GameObject woman;
    public GameObject old_man;
    public GameObject old_woman;
    public GameObject dog;
    public GameObject pregnant;

    private GameObject leftPrefab;
    private GameObject rightPrefab;

    public string leftDB;
    public string rightDB;

    void Awake()
    {
        int leftChoice = Random.Range(1, 9);

        int rightChoice = 0;
        do
        {
            rightChoice = Random.Range(1, 9);
        } while (rightChoice == leftChoice);

        switch (leftChoice)
        {
		case 1:
			leftPrefab = boy;
                break;
		case 2:
			leftPrefab = girl;
                break;
		case 3:
			leftPrefab = man;
                break;
		case 4:
			leftPrefab = woman;
                break;
		case 5:
			leftPrefab = old_man;
                break;
		case 6:
			leftPrefab = old_woman;
                break;
		case 7:
			leftPrefab = dog;
                break;
		case 8:
			leftPrefab = pregnant;
                break;
        }
        switch (rightChoice)
        {
		case 1:
			rightPrefab = boy;
                break;
		case 2:
			rightPrefab = girl;
                break;
		case 3:
			rightPrefab = man;
                break;
		case 4:
			rightPrefab = woman;
                break;
		case 5:
			rightPrefab = old_man;
                break;
		case 6:
			rightPrefab = old_woman;
                break;
		case 7:
			rightPrefab = dog;
                break;
		case 8:
			rightPrefab = pregnant;
                break;
        }

        leftDB = leftPrefab.name;
        rightDB = rightPrefab.name;

        Vector3 leftPos = left.GetComponent<Transform>().position;
        Quaternion leftRot = left.GetComponent<Transform>().rotation;
        string leftWay = left.GetComponent<People>().waypoint;
        left.SetActive(false);

        GameObject leftPers = Instantiate(leftPrefab, leftPos, leftRot) as GameObject;
        leftPers.GetComponent<People>().waypoint = leftWay;

        int leftMult = Random.Range(1, 8);  // probability of 1/7
        if (leftMult == 1)
        {
            leftDB += "_Group";
            
            leftPers.transform.Find("transform1").GetComponent<TextMesh>().text = leftPers.transform.Find("transform1").GetComponent<TextMesh>().text + " Group";
            leftPers.transform.Find("transform1").GetComponent<TextMesh>().fontSize = 50;

            GameObject leftPers2 = Instantiate(leftPrefab, leftPos + new Vector3(-1.2f, 0.0f, -1.2f), leftRot) as GameObject;
            GameObject leftPers3 = Instantiate(leftPrefab, leftPos + new Vector3(-0.7f, 0.0f, -2.8f), leftRot) as GameObject;
            GameObject leftPers4 = Instantiate(leftPrefab, leftPos + new Vector3(0.5f, 0.0f, -3.2f), leftRot) as GameObject;
            GameObject leftPers5 = Instantiate(leftPrefab, leftPos + new Vector3(1.1f, 0.0f, -1.4f), leftRot) as GameObject;
            
            Destroy(leftPers2.transform.Find("transform1").GetComponent<TextMesh>());
            Destroy(leftPers3.transform.Find("transform1").GetComponent<TextMesh>());
            Destroy(leftPers4.transform.Find("transform1").GetComponent<TextMesh>());
            Destroy(leftPers5.transform.Find("transform1").GetComponent<TextMesh>());

            leftPers2.GetComponent<People>().waypoint = leftWay;
            leftPers3.GetComponent<People>().waypoint = leftWay;
            leftPers4.GetComponent<People>().waypoint = leftWay;
            leftPers5.GetComponent<People>().waypoint = leftWay;
        }


        Vector3 rightPos = right.GetComponent<Transform>().position;
        Quaternion rightRot = right.GetComponent<Transform>().rotation;
        string rightWay = right.GetComponent<People>().waypoint;
        right.SetActive(false);

        GameObject rightPers = Instantiate(rightPrefab, rightPos, rightRot) as GameObject;
        rightPers.GetComponent<People>().waypoint = rightWay;

        int rightMult = Random.Range(1, 8); // probability of 1/7
        if (rightMult == 1)
        {
            rightDB += "_Group";
            
            rightPers.transform.Find("transform1").GetComponent<TextMesh>().text = rightPers.transform.Find("transform1").GetComponent<TextMesh>().text + " Group";
            rightPers.transform.Find("transform1").GetComponent<TextMesh>().fontSize = 50;

            GameObject rightPers2 = Instantiate(rightPrefab, rightPos + new Vector3(-0.6f, 0.0f, 1.1f), rightRot) as GameObject;
            GameObject rightPers3 = Instantiate(rightPrefab, rightPos + new Vector3(-0.7f, 0.0f, -0.7f), rightRot) as GameObject;
            GameObject rightPers4 = Instantiate(rightPrefab, rightPos + new Vector3(0.5f, 0.0f, -1.0f), rightRot) as GameObject;
            GameObject rightPers5 = Instantiate(rightPrefab, rightPos + new Vector3(0.6f, 0.0f, 0.9f), rightRot) as GameObject;
            
            Destroy(rightPers2.transform.Find("transform1").GetComponent<TextMesh>());
            Destroy(rightPers3.transform.Find("transform1").GetComponent<TextMesh>());
            Destroy(rightPers4.transform.Find("transform1").GetComponent<TextMesh>());
            Destroy(rightPers5.transform.Find("transform1").GetComponent<TextMesh>());

            rightPers2.GetComponent<People>().waypoint = rightWay;
            rightPers3.GetComponent<People>().waypoint = rightWay;
            rightPers4.GetComponent<People>().waypoint = rightWay;
            rightPers5.GetComponent<People>().waypoint = rightWay;
        }
		SendData ();
    }

	void SendData()
	{
		string url = "http://bugejamark.com/GameAI3/databaseInsertCombination.php";
		int sceneNumber;
		WWWForm form = new WWWForm();
		form.AddField("Right", rightDB);
		string scene = SceneManager.GetActiveScene().name;
		if (scene [6] != '.'){
			sceneNumber = int.Parse ("" + scene [5]+scene[6]);
		} else {
			sceneNumber = int.Parse ("" + scene [5]);
		}
		if (sceneNumber != 10 && sceneNumber != 9) {
			form.AddField ("Left", leftDB);
		} else {
			form.AddField ("Left", "Car");
		}

		
		WWW www = new WWW (url, form);

		StartCoroutine(this.gameObject.GetComponent<POSTDataGlobal>().WaitForRequest(www));
	}

    void Start()
    {
        Time.timeScale = 1;
    }

}