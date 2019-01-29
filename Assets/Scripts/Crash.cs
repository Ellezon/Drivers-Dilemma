using UnityEngine;
using System.Collections;

public class Crash : MonoBehaviour {

    void OnTriggerEnter(Collider collide)
    {
        bool crashed = false;

        if (collide.gameObject.tag == "Untagged")
        {
            transform.GetChild(3).gameObject.SetActive(true);
            crashed = true;
            transform.GetChild(2).gameObject.SetActive(false);
        } else if (collide.gameObject.tag == "Citizen" && crashed == false)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
