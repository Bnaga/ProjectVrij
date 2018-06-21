using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookingAtCHIPS : MonoBehaviour {

	public float length = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, length))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
			CHIPS chips = hit.transform.GetComponent<CHIPS>();
			if (chips){
				chips.NextScreen();
			}
        }
	}

	

}
