using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHIPSStorage : MonoBehaviour {

	public static List<AudioClip> storage = new List<AudioClip>();
	public static CHIPSStorage self;
	public fishDictionary Dictionary;

	private AudioSource source;
	public int current;

	[SerializeField]
	public Button[] useButtons;

	// Use this for initialization
	public void Awake() {
		self = this;
		source = GetComponent<AudioSource>();
	}

	public void ClearAll(){
		storage.Clear();
		foreach (fishDictionary.word word in Dictionary.dictionary){
			storage.Add(null);
		}
	}

	public void Init(int i){
		gameObject.SetActive(true);
		source.clip = storage[i];
		foreach (Button b in useButtons){
			b.interactable = storage[current] != null;
		}
	}

	public void Upload(){
		storage[current] = MicrophoneControllerVR.audioRecording;
		Init(current);
	}

	public void Download(){
	MicrophoneControllerVR.audioRecording = storage[current];
	}

	public void Clear(){
		storage[current] = null;
		Init(current);
	}

	public void Play(){
		if (!source.isPlaying){
			source.Play();
		}
	}

	public void disable(){
		gameObject.SetActive(false);
	}
}
