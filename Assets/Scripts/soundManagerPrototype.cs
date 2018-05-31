using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerPrototype : MonoBehaviour {

	public float soundFrequency;
	public GameObject speechBalloon;
	private soundCommunication soundCommunication;
	private float soundTimer;
	

	public fishDictionary dictionary;
	private fishDictionary.word[] words;
	// Use this for initialization
	void Start () {
		soundCommunication = GetComponent<soundCommunication>();
		words = dictionary.dictionary;
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer += Time.deltaTime;
		if (soundTimer > soundFrequency){
			fishDictionary.word sound = words[Random.Range(0,words.Length)];
			soundCommunication.playWord(sound, dictionary);
			soundTimer = Random.Range(-soundFrequency/2,0);
			GameObject balloon = Instantiate(speechBalloon,transform, false);
			balloon.GetComponent<speechBalloon>().init(sound);

		}	
	}

}
