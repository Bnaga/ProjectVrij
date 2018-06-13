using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour {

	public AudioClip[] sounds;
	public float soundFrequency;
	private float soundTimer;
	private AudioSource source;
	
	// Use this for initialization
	void Start () {
		soundTimer= Random.Range(0,soundFrequency);
		AudioSource settings = audiosourceSettings.source;
		AudioSource source  = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
		source.spatialBlend	= settings.spatialBlend;
		source.spatialize	= settings.spatialize;
		source.rolloffMode 	= settings.rolloffMode;
		source.rolloffMode	= settings.rolloffMode;
		source.maxDistance	= settings.maxDistance;

		source.SetCustomCurve(AudioSourceCurveType.CustomRolloff,settings.GetCustomCurve(AudioSourceCurveType.CustomRolloff));
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer += Time.deltaTime;
		if (soundTimer>soundFrequency){
			soundTimer= Random.Range(-soundFrequency/8,0);
			Play();
		}
	}

	public void Play(){
		if (source.isPlaying) return;
		source.clip = sounds[Random.Range(0,sounds.Length)];
		source.Play();

	}
}
