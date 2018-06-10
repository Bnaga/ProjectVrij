using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneController : MonoBehaviour {
	[SerializeField]
	private AudioListener characterListener;
	[SerializeField]
	private soundCommunication playbackDevice;
	
	[SerializeField]
	private GameObject microphone;
	private AudioListener microphoneListener;
	private audioRecorder audioRecorder;
	[SerializeField]
	private soundCommunication microphoneCommunication;
	private AudioClip audioRecording;
	private List <fishDictionary.word> playbackWords = new List<fishDictionary.word>();
	private bool isRecording;

	void Start(){
		microphoneListener = microphone.GetComponent<AudioListener>();
		audioRecorder = microphone.GetComponent<audioRecorder>();
	}

	void Update () {
		isRecording = Input.GetButton("Fire1");
		if (!microphoneListener.enabled && isRecording){
			audioRecorder.StartRecording();
			microphoneCommunication.receivedWords.Clear();
		}
		if (microphoneListener.enabled && !isRecording){
			audioRecording=audioRecorder.StopRecording();
			playbackWords = microphoneCommunication.receivedWords;
		}

		microphoneListener.enabled = isRecording;
		characterListener.enabled = !isRecording;

		if (Input.GetButtonDown("Fire2")){
			playbackDevice.receivedWords = playbackWords;
			playbackDevice.PlaySound(audioRecording);
		}
	}
}


