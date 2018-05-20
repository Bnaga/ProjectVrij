using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHIPS : MonoBehaviour {


	public fishDictionary[] dictionaries;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("hit chips");
		soundCommunication comms = other.GetComponent<soundCommunication>();
		if (!comms || !other.GetComponent<AudioListener>()) return;
		Debug.Log("found comms");

		foreach (AudioClip clip in comms.receivedSounds){
			foreach (fishDictionary dict in dictionaries){
				int i =0;
				foreach (fishDictionary.word w in dict.dictionary){
					if (w.audio == clip) dict.dictionary[i].known = true;
					i++;
				}
			}
		}
	}
}
