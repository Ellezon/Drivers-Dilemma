using UnityEngine;
using System.Collections;

public class HelperScript : MonoBehaviour {

	void OnTriggerEnter(Collider collide)
	{
		if((collide.gameObject.tag == "Car") && (collide.GetType() == typeof(CapsuleCollider))) 
		{
			Destroy (gameObject);
		}
	}
}