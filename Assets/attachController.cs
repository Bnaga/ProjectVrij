using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachController : MonoBehaviour {

	public GameObject controller;
	private Rigidbody RB;
	private FixedJoint FJ;
	// Use this for initialization
	void Start () {
		RB = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
		FJ = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
		FJ.connectedBody = controller.GetComponent<Rigidbody>();
		
		transform.position=controller.transform.position;
		transform.rotation=controller.transform.rotation;
	}
	
}
