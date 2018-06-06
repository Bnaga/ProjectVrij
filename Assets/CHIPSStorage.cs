using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHIPSStorage : MonoBehaviour {

	public static List<AudioClip> storage = new List<AudioClip>();
	public static CHIPSStorage self;
	private AudioSource source;
	private int current;

	[SerializeField]
	public Button[] useButtons;

	// Use this for initialization
	void Start () {
		self = this;
		source = GetComponent<AudioSource>();
	}

	public void Init(int i){
		current = i;
		source.clip = storage[i];
		foreach (Button b in useButtons){
			b.interactable = storage[current];
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
		self.SetActive(false);
	}
}
