using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneToggle : MonoBehaviour {

	[SerializeField]
	private AudioListener microphoneListener;
	[SerializeField]
	private AudioListener characterListener;

	private AudioClip audioRecording;
	[SerializeField]
	private AudioSource playbackSource;
	private bool recordingState;

	void Update () {
		recordingState = Input.GetButton("Fire1");

		if (!microphoneListener.enabled && recordingState){
			//AudioListener.GetOutputData
		}
		if (microphoneListener.enabled && !recordingState){

		}
		//SavWav.Save("test.wav",audioRecording);
		
		microphoneListener.enabled = recordingState;
		characterListener.enabled = !recordingState;

		if (Input.GetButton("Fire2")){
			playbackSource.clip = audioRecording;
			playbackSource.Play();
		}
	}
}
