using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    public float speed = 0.1f;
    public float rotationSpeed =2f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 2.0f;
	private Rigidbody rb;
	public float speedscale;
    private float realSpeed;
    private int applycounter;
    private Vector3 goalPos;
    public Vector3 nullPos;
    private Quaternion turnRot;

    bool touching = false;

    bool turning = false;

	// Use this for initialization
	void Start ()
    {
        speed = Random.Range(1, 2);
        rb = GetComponent<Rigidbody>();
	}

   
	// Update is called once per frame
	void Update ()
    {
        realSpeed = Mathf.Max(1,Vector3.Magnitude( rb.velocity));
        if (Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.tankSize)
        {
            turning = true;
        }
        else if (!touching) turning = false;

        if (turning)
        {
            Vector3 direction = (goalPos+nullPos)/2 - transform.position;
            Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed/(realSpeed) * Time.deltaTime);
            rb.MoveRotation(rot);
            speed = Random.Range(1, 2);
        }
        else
        {
            Quaternion rot =  Quaternion.Slerp(transform.rotation, turnRot, rotationSpeed/(realSpeed) * Time.deltaTime);
            rb.MoveRotation(rot);
            turnRot = Quaternion.Slerp(Quaternion.identity, turnRot, 1-rotationSpeed/(realSpeed) * Time.deltaTime);
            applycounter--;
            if (applycounter<0)
            {
                ApplyRules();
            }
        }
        //transform.Translate(0, 0, Time.deltaTime * speed);
		rb.AddForce(transform.forward * Time.deltaTime * speed * speedscale);
	}

    void ApplyRules()
    {
        if (Random.Range(0,5)<1)
            turnRot = Quaternion.Euler(Random.Range(-180,180),Random.Range(-40,40),0);
        applycounter = Random.Range(10,20);
        GameObject[] gos;
        gos = GlobalFlock.allFIsh;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 1f;

        goalPos = GlobalFlock.goalPos;
        Debug.DrawLine(transform.position,goalPos);

        if (Vector3.Distance(transform.position,goalPos)<1f){
            //GlobalFlock.newGoal(transform.position);
        };
        float dist;

        int groupSize = 0;
        foreach(GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if(dist < 3.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }
        if(groupSize > 0)
        {
            vcenter = vcenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.position;
            if(direction != Vector3.zero)
            {

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed/realSpeed * Time.deltaTime);
            }
        }
    }

     void OnTriggerEnter(){
        touching=true;
        turning=true;
    }

    void OnTriggerExit(){
        touching=false;
    }
	
}
