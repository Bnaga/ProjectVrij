using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour {

	public AudioClip[] sounds;
	public float soundFrequency;
	private float soundTimer;
	private AudioSource source;
	public static int isPlaying;
	
	// Use this for initialization
	void Awake () {
		soundTimer= Random.Range(0,soundFrequency);
		AudioSource settings = audiosourceSettings.source;
		source  			= gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
		source.spatialBlend	= settings.spatialBlend;
		source.spatialize	= settings.spatialize;
		source.rolloffMode 	= settings.rolloffMode;
		source.rolloffMode	= settings.rolloffMode;
		source.maxDistance	= settings.maxDistance;
		source.playOnAwake 	= settings.playOnAwake;
		source.dopplerLevel	= settings.dopplerLevel;
		source.priority 	= Random.Range(100,256);
		source.volume		= settings.volume;
		source.spread 		= settings.spread;


		source.SetCustomCurve(AudioSourceCurveType.CustomRolloff,settings.GetCustomCurve(AudioSourceCurveType.CustomRolloff));
	}
	
	// Update is called once per frame
	void Update () {
		soundTimer += Time.deltaTime;
		if (soundTimer>soundFrequency){
			soundTimer= Random.Range(-soundFrequency/8,0);
			if (Random.value>.5f) return;
			float d = Vector3.Distance(transform.position,Camera.main.transform.position);
			if ( d< source.maxDistance/2 && isPlaying <5) 
				StartCoroutine( Play());
		}
	}

	IEnumerator Play(){
		isPlaying++;
		source.clip = sounds[Random.Range(0,sounds.Length)];
		source.Play();
		yield return  new WaitForSeconds(source.clip.length);
		isPlaying--;

	}

	/*void OnDrawGizmos(){
		if (source)
			Gizmos.DrawWireSphere(transform.position,source.maxDistance);
	}
	*/
}
