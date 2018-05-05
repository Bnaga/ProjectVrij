using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerPrototype : MonoBehaviour {

	public AudioClip[] Sounds;
	public float soundFrequency;
	private soundCommunication soundCommunication;
	private float soundTimer;
	private ParticleSystem bubbles;
	// Use this for initialization
	void Start () {
		bubbles = GetComponent<ParticleSystem>();
		soundCommunication = GetComponent<soundCommunication>();
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer += Time.deltaTime;
		if (soundTimer > soundFrequency){
			soundCommunication.PlaySound(Sounds[Random.Range(0,Sounds.Length)]);
			soundTimer = Random.Range(-soundFrequency/2,0);
			bubbles.Play();
		}	
	}

}
