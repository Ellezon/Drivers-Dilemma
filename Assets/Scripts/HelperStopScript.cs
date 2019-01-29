using UnityEngine;
using System.Collections;

public class HelperStopScript: MonoBehaviour
{

	void OnTriggerEnter(Collider collide)
	{
        if ((collide.gameObject.tag == "Car") && (collide.GetType() == typeof(CapsuleCollider))) {
            collide.gameObject.GetComponent<DrivingScript> ().SetDriving (false);
			StartCoroutine (WaitThenDrive (collide.gameObject));
		}
	}
	IEnumerator WaitThenDrive(GameObject car)
	{
		yield return new WaitForSeconds(1f);
		car.GetComponent<DrivingScript>().SetDriving(true);
		car.GetComponent<DrivingScript>().IncrementIndex();
		Destroy (gameObject);
	}
}
