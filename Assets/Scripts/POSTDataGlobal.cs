using UnityEngine;
using System.Collections;

public class POSTDataGlobal : MonoBehaviour {

	public IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		} 

	}    
}
