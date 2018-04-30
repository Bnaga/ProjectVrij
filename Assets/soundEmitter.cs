using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEmitter : MonoBehaviour {

	public AudioClip testClip;
	private SphereCollider soundSphere;
	private bool playing;
	private float soundTimer;
	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		soundSphere = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
		soundSphere.radius=8;
		soundSphere.isTrigger=true;
		
		if (GetComponent<AudioSource>()){
			audioSource=GetComponent<AudioSource>();
		}else{
			audioSource=gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
			audioSource.spatialBlend=1;
		}
		PlaySound(testClip);
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer-=Time.deltaTime;
		soundSphere.enabled= soundTimer>0;
	}

	void OnTriggerEnter (Collider other){
		soundReceiver sr = other.GetComponent<soundReceiver>();
		if (!sr) return;
		sr.ReceiveSound(audioSource.clip);

	}

	public void PlaySound(AudioClip clip){
		if (clip.length > soundTimer) soundTimer=clip.length;
		audioSource.clip=clip;
		audioSource.Play();
	}
}
