using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kelpFloat : MonoBehaviour {
	 public float floatStrength = 3.5f;
	 private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(Vector3.up * floatStrength);
	}
}
