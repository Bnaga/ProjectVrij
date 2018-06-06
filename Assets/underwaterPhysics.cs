using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underwaterPhysics : MonoBehaviour {

	public bool alwaysActive = false;
	public float floating;
	public int UpdateEveryXFrames = 10;
	[HideInInspector]
	public int updateCounter;
	private Rigidbody rigidbody;
	private float density;
	private Vector3 force;

	// Use this for initialization
	void Awake () {
		rigidbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		updateCounter++;
		if (updateCounter>UpdateEveryXFrames){
			updateCounter=0;
			if (alwaysActive || Mathf.Abs(rigidbody.velocity.y)>.1f){
				force += Random.insideUnitSphere * rigidbody.drag;
				force.y=0;
				if (floating>0) force.y = floating;
				Debug.DrawLine(transform.position,transform.position+force/rigidbody.drag, Color.red);
			}
		}
		if (force.magnitude>1){
			rigidbody.AddForce(force, ForceMode.Acceleration);
			force/=2;
		}
	}

}
