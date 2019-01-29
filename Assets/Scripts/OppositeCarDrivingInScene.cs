using UnityEngine;
using System.Collections;

public class OppositeCarDrivingInScene : MonoBehaviour
{
    private Transform endMarker;
    //private float startTime;
    private float speed = 5.0F;
    private int index = 1;
    private float distance;
    private bool isDriving;
    private int max = 26; //one more than waypoint number
    private string direction;

    // Use this for initialization
    void Start()
    {
        //startTime = Time.time;
        isDriving = true;
        direction = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isDriving)
        {

            endMarker = GameObject.Find(direction + "STRAIGHTGroupWaypoint (" + index + ")").transform;
            transform.rotation = Quaternion.Lerp(transform.rotation, endMarker.rotation, 0.15F);
            transform.position = Vector3.MoveTowards(transform.position, endMarker.position, speed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, endMarker.position);
        }

        if (distance < 3 && !(endMarker.gameObject.tag == "Stop" || endMarker.gameObject.tag == "Slow"))
        {
            Destroy(endMarker.gameObject);
            IncrementIndex();
        }
        else if (index == max)
        {
            isDriving = false;
        }
    }

    public void SetSpeed(float inspeed)
    {
        //speed = inspeed;
    }

    public void SetDriving(bool indrive)
    {
        isDriving = indrive;
    }

    public void SetDirection(string directionIn)
    {
        direction = directionIn;
    }

    public void IncrementIndex()
    {
        index++;
    }
}


