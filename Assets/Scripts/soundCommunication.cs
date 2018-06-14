using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundCommunication : MonoBehaviour {

	public AudioClip testClip;
	private SphereCollider soundSphere;
	private bool playing;
	private float soundTimer;
	
//	[HideInInspector]
	public List <fishDictionary.word> receivedWords = new List<fishDictionary.word>();
	private fishDictionary.word currentWord;
	public bool playbackDevice;

	public float soundRange = .5f;
	private List <AudioSource> sources = new List<AudioSource>();
	private AudioSource sourceFar;
	[HideInInspector]
	public AudioSource sourceNear;

	void Start () {

		//if (!GetComponent<Rigidbody>()) Debug.Log("No RigidBody on" + gameObject.name);
		if (!GetComponent<Rigidbody>()){
			Rigidbody rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
			rb.useGravity=false;
			rb.isKinematic=true;
		}
		
		AudioSource settings = audiosourceSettings.source;
		for (int i = 0; i < 2; i++){
			AudioSource audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
			audioSource.spatialBlend	= settings.spatialBlend;
			audioSource.spatialize		= settings.spatialize;
			audioSource.rolloffMode 	= settings.rolloffMode;
			audioSource.rolloffMode		= settings.rolloffMode;
			audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff,settings.GetCustomCurve(AudioSourceCurveType.CustomRolloff));
			
			audioSource.maxDistance = soundRange*2;
			
			
			sources.Add(audioSource);

		}
		sourceNear = sources[0];
		sourceNear.volume=.4f;
		if (playbackDevice) sourceNear.volume = 1.5f;

		sourceFar = sources[1];
		sourceFar.maxDistance *= 8;
		sourceFar.volume = .1f;
		
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
		//if (playbackDevice) knownWordManager.wordBalloon(transform.position, receivedWords[0]);
	}

	public void PlayRandomSound(AudioClip[] clips){
		AudioClip clip = clips[Random.Range(0,clips.Length-1)];
		PlaySound(clip);
	}

	public void playWord(fishDictionary.word word, fishDictionary dictionary){
		PlayRandomSound(word.audio);
		currentWord = word;
		AudioClip far = dictionary.far[word.farawaySound];
		if (sourceFar.clip !=far) StartCoroutine(NextSound(far,sourceFar));
		knownWordManager.wordBalloon(transform.position, word);
		
	}

	void OnTriggerEnter (Collider other){
		soundCommunication sc = other.GetComponent<soundCommunication>();
		if (!sc || !sc.enabled) return;
		if (!sourceNear.clip) return;
		if (!playbackDevice){
			sc.ReceiveSound(currentWord);
		}else{
			foreach (fishDictionary.word word in receivedWords){
				sc.ReceiveSound(word);
			}
		}

	}

	public void ReceiveSound(fishDictionary.word word){
		if (!playbackDevice && !receivedWords.Contains(word)) receivedWords.Add(word);
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
		audioSource.clip = next;
        audioSource.volume = startVolume;
		audioSource.Play();
    }
 

}
