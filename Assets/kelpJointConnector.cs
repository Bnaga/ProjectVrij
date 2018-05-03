using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class kelpJointConnector : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
	}
	

}
