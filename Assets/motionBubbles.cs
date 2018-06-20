using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionBubbles : MonoBehaviour {

	public float speed;
	private ParticleSystem.EmissionModule ps;
	private Vector3 oldpos;
	private Vector3 newpos;
	private Vector3 velocity;

	void Awake(){
 
    oldpos = transform.position;
 
		ps = GetComponent<ParticleSystem>().emission;
	}
	void Update () {

	newpos = transform.position;
    velocity =  (newpos - oldpos) / Time.deltaTime;
    oldpos = newpos;
	ps.enabled = velocity.magnitude > speed;
	}
}
