using UnityEngine;
using System.Collections;

public class Flock : MonoBehaviour {

	public float maxSpeed;
    private float speed;
	//public float turnSpeed = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;
	float neighborDistance = 3.0f;

	bool turning = false;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		speed = Random.Range (2f, maxSpeed);
        rb= GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
       
		ApplyTankBoundary ();
         RaycastHit hit;
		if (Physics.Raycast(transform.position,transform.forward, out hit, .5f))
        {
             Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            ApplyRules(GlobalFlock.defaultPos);
        }
		if(turning) {
			Vector3 direction = Vector3.zero - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation,
				Quaternion.LookRotation (direction),
				TurnSpeed () * Time.deltaTime);
			speed = Random.Range (2f, maxSpeed);
		} else {
			if (Random.Range (0, 5) < 1)
				DefaultRules ();
		}
        
        if (rb.velocity.magnitude<maxSpeed/4)
            rb.AddForce(transform.forward*Time.deltaTime*speed *rb.mass);

	}

      void OnCollisionEnter(Collision collision)
    {
       speed= maxSpeed;
       ApplyRules(-GlobalFlock.goalPos);
	   //ApplyRules(GlobalFlock.defaultPos);
    }

	void ApplyTankBoundary() {
		if(Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.tankSize) {
			turning = true;
		} else {
			turning = false;
		}
	}
    void DefaultRules(){
        ApplyRules(GlobalFlock.goalPos);
    }
	void ApplyRules(Vector3 goalPos) {
		GameObject[] gos;
		gos = GlobalFlock.allFish;

		Vector3 vCenter = Vector3.zero;
		Vector3 vAvoid = Vector3.zero;
		float gSpeed = 0.1f;


		float dist;
		int groupSize = 0;

		foreach (GameObject go in gos) {
			if (go != this.gameObject) {
				dist = Vector3.Distance (go.transform.position, this.transform.position);
				if (dist <= neighborDistance) {
					vCenter += go.transform.position;
					groupSize++;

					if(dist < 0.75f) {
						vAvoid = vAvoid + (this.transform.position - go.transform.position);
					}

					Flock anotherFish = go.GetComponent<Flock> ();
					gSpeed += anotherFish.speed;
				}

			}
		}

		if (groupSize > 0) {
			vCenter = vCenter / groupSize + (goalPos - this.transform.position);
			//speed = gSpeed / groupSize;

			Vector3 direction = (vCenter + vAvoid) - transform.position;
			if (direction != Vector3.zero) {
				transform.rotation = Quaternion.Slerp (transform.rotation,
					Quaternion.LookRotation (direction),
					TurnSpeed () * Time.deltaTime);
			}
		}

 	}

	float TurnSpeed() {
		return Random.Range (0.2f, 0.6f);
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(transform.position, transform.position+transform.forward*.5f);
    }
 }