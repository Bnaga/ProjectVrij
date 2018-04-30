using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundReceiver : MonoBehaviour {

	public AudioClip receivedSound;
	// Use this for initialization

	public void ReceiveSound(AudioClip clip){
		receivedSound = clip;
		Debug.Log(clip.name);
	}

	void Start(){
		if (!GetComponent<Rigidbody>()) Debug.Log("NO RIGIDBODY");
	}
}
