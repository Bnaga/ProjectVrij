using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CHIPS : MonoBehaviour {


	public fishDictionary[] dictionaries;
	public TextMeshPro display;

	void Awake () {
		//reset known words
		foreach (fishDictionary dict in dictionaries){
				foreach (fishDictionary.word w in dict.dictionary){
					w.known = w.knownFromStart;
				}
			}
			updateScreen();
	}
	
	// Update is called once per frame
	void Update () {
		updateScreen();
	}

	void OnTriggerEnter(Collider other){
		soundCommunication comms = other.GetComponent<soundCommunication>();
		if (!comms || !other.GetComponent<AudioListener>()) return;
		Debug.Log("UPDATED CHIPS");
		
		/*foreach (fishDictionary.word word in comms.receivedWords){
			foreach (fishDictionary dict in dictionaries){
				foreach (fishDictionary.word w in dict.dictionary){
					if (word== w) w.known = true;
			
				}
			}
		}*/

		updateScreen();
	}

	

	void updateScreen(){
		string text = "Known Words:\n";
		foreach (fishDictionary dict in dictionaries){
				foreach (fishDictionary.word w in dict.dictionary){
					if (w.known) {text+=w.meaning + "\n";}
					else{text+="????\n";}
				}
			}
			display.SetText(text);
	}
}
