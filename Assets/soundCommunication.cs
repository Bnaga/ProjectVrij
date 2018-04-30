using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundCommunication : MonoBehaviour {

	public AudioClip testClip;
	private SphereCollider soundSphere;
	private bool playing;
	private float soundTimer;
	private AudioSource audioSource;
	[HideInInspector]
	public List <AudioClip> receivedSounds = new List<AudioClip>();

	void Start () {

		if (!GetComponent<Rigidbody>()) Debug.Log("No RigidBody on" + gameObject.name);
		
		if (GetComponent<AudioSource>()){
			audioSource=GetComponent<AudioSource>();
		}else{
			audioSource=gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
			audioSource.spatialBlend=1;
			audioSource.spatialize=true;
		}
		
		soundSphere = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
		soundSphere.radius=8;
		soundSphere.isTrigger=true;

		if (testClip) PlaySound(testClip);
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer-=Time.deltaTime;
		soundSphere.enabled= soundTimer>0;
	}


	public void PlaySound(AudioClip clip){
		if (clip.length > soundTimer) soundTimer=clip.length;
		audioSource.clip=clip;
		audioSource.Play();
	}

	void OnTriggerEnter (Collider other){
		soundCommunication sc = other.GetComponent<soundCommunication>();
		if (!sc || !audioSource.clip) return;
		sc.ReceiveSound(audioSource.clip);

	}

	public void ReceiveSound(AudioClip clip){
		if (!receivedSounds.Contains(clip)) receivedSounds.Add(clip);
		Debug.Log(clip.name);
	}

}
