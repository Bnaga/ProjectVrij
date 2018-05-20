using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerPrototype : MonoBehaviour {

	public float soundFrequency;
	public GameObject speechBalloon;
	private soundCommunication soundCommunication;
	private float soundTimer;
	private ParticleSystem bubbles;
	

	public fishDictionary fishType;
	private fishDictionary.word[] dictionary;
	// Use this for initialization
	void Start () {
		bubbles = GetComponent<ParticleSystem>();
		soundCommunication = GetComponent<soundCommunication>();
		dictionary = fishType.dictionary;
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer += Time.deltaTime;
		if (soundTimer > soundFrequency){
			fishDictionary.word sound = dictionary[Random.Range(0,dictionary.Length)];
			soundCommunication.PlaySound(sound.audio);
			soundTimer = Random.Range(-soundFrequency/2,0);
			bubbles.Play();
			GameObject balloon = Instantiate(speechBalloon,transform, false);
			balloon.GetComponent<speechBalloon>().init(sound);

		}	
	}

}
