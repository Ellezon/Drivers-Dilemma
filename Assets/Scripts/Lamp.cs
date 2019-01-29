using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {

    private bool isFalling;
    private Transform fallTo;

    void Start()
    {
        isFalling = false;
        fallTo = GameObject.Find("Lamp Waypoint").transform;
    }
    
    void Update()
    {
        if (isFalling)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, fallTo.rotation, 0.4F * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Car") && (col.GetType() == typeof(SphereCollider)))
        {
            isFalling = true;
        } else
        {
            isFalling = false;
        }
    }
}
