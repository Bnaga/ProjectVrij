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
	private List <AudioClip> playbackSounds = new List<AudioClip>();
	private bool isRecording;

	void Start(){
		microphoneListener = microphone.GetComponent<AudioListener>();
		audioRecorder = microphone.GetComponent<audioRecorder>();
	}

	void Update () {
		isRecording = Input.GetButton("Fire1");
		if (!microphoneListener.enabled && isRecording){
			audioRecorder.StartRecording();
			microphoneCommunication.receivedSounds.Clear();
		}
		if (microphoneListener.enabled && !isRecording){
			audioRecording=audioRecorder.StopRecording();
			playbackSounds = microphoneCommunication.receivedSounds;
		}

		microphoneListener.enabled = isRecording;
		characterListener.enabled = !isRecording;

		if (Input.GetButtonDown("Fire2")){
			playbackDevice.receivedSounds = playbackSounds;
			playbackDevice.PlaySound(audioRecording);
		}
	}
}


