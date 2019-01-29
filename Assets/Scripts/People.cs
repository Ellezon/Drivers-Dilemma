using UnityEngine;
using System.Collections;

public class People : MonoBehaviour {

    public string waypoint;
    private Transform walkTo;
    private Rigidbody body;
    private Animator animator;

    private bool isWalking;
    private bool isRunning;
    private bool isDead;
    
    private AudioSource audioSource;

    void Awake ()
    {
        audioSource = GetComponent<AudioSource>();
    }

	void Start () {
        if (waypoint == "None") isWalking = false;
        else {
            walkTo = GameObject.Find(waypoint).transform;
        }

        body = GetComponentInChildren<HingeJoint>().connectedBody;
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        if (!isDead)
        {
            if (isRunning)
            {
                transform.position = Vector3.MoveTowards(transform.position, walkTo.position, 2.0F * Time.deltaTime);
            }
            else if (isWalking)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, walkTo.rotation, 2.0F * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, walkTo.position, 1.5F * Time.deltaTime);
            }
        }
    }

	void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Car")
        {
            if (col.GetType() == typeof(CapsuleCollider))
            {
                isDead = true;
                Destroy(animator);

                body.isKinematic = false;
                body.freezeRotation = false;
                audioSource.Play();
                body.AddExplosionForce(3000F, col.transform.position, 1000F, 0.0F);

                StartCoroutine(Separate());
            }
            else if ((col.GetType() == typeof(SphereCollider)) && (animator != null) && (waypoint != "None"))
            {
                isWalking = true;
                animator.SetBool("isWalking", isWalking);
            }
            else if ((col.GetType() == typeof(BoxCollider)) && (animator != null))
            {
                isRunning = true;
                animator.SetBool("isRunning", isRunning);
            }
		}
	}

	IEnumerator Separate() {

        yield return new WaitForSeconds(0.1f);

        Component[] hingeJoints = GetComponentsInChildren<HingeJoint>();

		foreach (HingeJoint joint in hingeJoints) 
		{
			Destroy(joint);
        }
    }
}
