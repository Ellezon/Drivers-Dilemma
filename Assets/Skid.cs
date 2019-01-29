using UnityEngine;
using System.Collections;

public class Skid : MonoBehaviour {

    bool skidded;

    void Start()
    {
        skidded = false;
    }

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player" && !skidded)
        {
            gameObject.GetComponent<AudioSource>().PlayDelayed(1.5F);
            skidded = true;
        }
    }
}
