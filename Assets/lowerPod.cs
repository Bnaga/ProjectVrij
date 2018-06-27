using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowerPod : MonoBehaviour {

	public Vector3 Destination;
	public Transform messageSpot;
	public float speed;
	private GameObject balloon;

	public float delay = 180;
	private bool lowering = false;

	// Update is called once per frame

	void Start(){
		StartCoroutine(delayTimer());
	}
	void Update () {
		if (lowering){
			float l = Mathf.Min(1,Vector3.Distance(transform.position,Destination));
			transform.position = Vector3.MoveTowards(transform.position, Destination, l * speed * Time.deltaTime);
			if (l<1 && !balloon){
				balloon = Instantiate(knownWordManager.self.speechBalloon, messageSpot);
				balloon.GetComponent<speechBalloon>().init("It is time to return to the surface");
			}
		}

		
	}

	public IEnumerator delayTimer(){
		yield return new WaitForSeconds(delay);
		lowering=true;
	}
}
