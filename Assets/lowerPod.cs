using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowerPod : MonoBehaviour {

	public Vector3 Destination;
	public Transform messageSpot;
	public float speed;
	private GameObject balloon;

	// Update is called once per frame
	void Update () {
		float l = Mathf.Min(1,Vector3.Distance(transform.position,Destination));
		transform.position = Vector3.MoveTowards(transform.position, Destination, l * speed * Time.deltaTime);
		if (l<1 && !balloon){
			balloon = Instantiate(knownWordManager.self.speechBalloon, messageSpot);
			balloon.GetComponent<speechBalloon>().init("Touch pod to return to the surface");
		}
	}
}
