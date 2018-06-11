using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHIPSStorage : MonoBehaviour {

	public static List<AudioClip> storage = new List<AudioClip>();
	public static List<Texture2D> imgStorage = new List<Texture2D>();
	public static CHIPSStorage self;
	public fishDictionary Dictionary;

	private AudioSource source;
	public int current;

	[SerializeField]
	public Button[] useButtons;

	public Image SpectrumDisplay;

	// Use this for initialization
	public void Awake() {
		self = this;
		source = GetComponent<AudioSource>();
	}

	public void ClearAll(){
		storage.Clear();
		imgStorage.Clear();
		foreach (fishDictionary.word word in Dictionary.dictionary){
			storage.Add(null);
			imgStorage.Add(null);
		}
	}

	public void Init(int i){
		gameObject.SetActive(true);
		source.clip = storage[i];
		foreach (Button b in useButtons){
			b.interactable = storage[current] != null;
		}
		Texture2D tex = imgStorage[current];
		SpectrumDisplay.overrideSprite = Sprite.Create (tex, new Rect (0f, 0f, tex.width, tex.height), new Vector2 (0.5f, 0.5f));
	}

	public void Upload(){
		storage[current] = MicrophoneControllerVR.audioRecording;
		Init(current);
	}

	public void Download(){
	MicrophoneControllerVR.audioRecording = storage[current];
	MicrophoneControllerVR.audioImage = imgStorage[current];
	}

	public void Clear(){
		storage[current] = null;
		imgStorage[current] = null;
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
