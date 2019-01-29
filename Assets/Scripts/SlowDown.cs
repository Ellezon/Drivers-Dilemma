using UnityEngine;
using System.Collections;

public class SlowDown : MonoBehaviour {

	void OnTriggerEnter(Collider collide){
		if (collide.gameObject.tag == "Car")
		{
			collide.gameObject.GetComponent<DrivingScript>().SetSpeed(0.8F);
		}
	}

	void OnTriggerExit(Collider collide){
		if(collide.gameObject.tag == "Car")
		{
			collide.gameObject.GetComponent<DrivingScript>().SetSpeed(1.5F);
			Destroy (gameObject);
		}
	}
}
