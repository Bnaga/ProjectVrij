using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundCommunication : MonoBehaviour {

	public AudioClip testClip;
	private SphereCollider soundSphere;
	private bool playing;
	private float soundTimer;
	
//	[HideInInspector]
	public List <AudioClip> receivedSounds = new List<AudioClip>();
	public bool playbackDevice;

	public float soundRange;
	private List <AudioSource> sources = new List<AudioSource>();
	private AudioSource sourceFar;
	private AudioSource sourceNear;

	void Awake () {

		//if (!GetComponent<Rigidbody>()) Debug.Log("No RigidBody on" + gameObject.name);
		if (!GetComponent<Rigidbody>()){
			Rigidbody rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
			rb.useGravity=false;
			rb.isKinematic=true;
		}
		
		for (int i = 0; i < 2; i++){
			AudioSource audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
			audioSource.spatialBlend=1;
			audioSource.spatialize=true;
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.minDistance = 0;
			audioSource.maxDistance = soundRange;
			
			
			sources.Add(audioSource);

		}
		sourceNear = sources[0];
		sourceFar = sources[1];
		sourceFar.maxDistance *= 5;
		sourceFar.volume = .2f;
		
		soundSphere = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
		soundSphere.radius = soundRange;
		soundSphere.isTrigger=true;

		if (testClip) PlaySound(testClip);
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer-=Time.deltaTime;
		soundSphere.enabled= soundTimer>0;
	}


	void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position,soundRange);
    }

	public void PlaySound(AudioClip clip){
		if (clip.length > soundTimer) soundTimer=clip.length;
		sourceNear.clip=clip;
		sourceNear.Play();
	}

	public void playWord(fishDictionary.word word, fishDictionary dictionary){
		PlaySound(word.audio);
		AudioClip far = dictionary.far[word.farawaySound];
		if (sourceFar.clip !=far) StartCoroutine(NextSound(far,sourceFar));
	}

	void OnTriggerEnter (Collider other){
		soundCommunication sc = other.GetComponent<soundCommunication>();
		if (!sc || !sc.enabled) return;
		if (!sourceNear.clip) return;
		if (!playbackDevice){
			sc.ReceiveSound(sourceNear.clip);
		}else{
			foreach (AudioClip a in receivedSounds){
				sc.ReceiveSound(a);
			}
		}

	}

	public void ReceiveSound(AudioClip clip){
		if (!playbackDevice && !receivedSounds.Contains(clip)) receivedSounds.Add(clip);
		//Debug.Log(clip.name);
	}

 
    public static IEnumerator NextSound (AudioClip next, AudioSource audioSource) {
        float startVolume = audioSource.volume;
		float FadeTime = 2;
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }

        audioSource.Stop ();
        audioSource.volume = startVolume;
    }
 

}
