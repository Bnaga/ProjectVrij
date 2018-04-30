using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneToggle : MonoBehaviour {

	[SerializeField]
	private AudioListener microphoneListener;
	[SerializeField]
	private AudioListener characterListener;
	[SerializeField]
	private audioRecorder audioRecorder;

	private AudioClip audioRecording;
	[SerializeField]
	private AudioSource playbackSource;
	private bool recordingState;

	void Update () {
		recordingState = Input.GetButton("Fire1");
		


		if (!microphoneListener.enabled && recordingState){
			audioRecorder.StartRecording();
			
			/*
			float[] spectrum = new float[256];
			AudioListener.GetOutputData(spectrum, 0);
			audioRecording = AudioClip.Create("Recording", spectrum.Length, 1,44100 , false);
			audioRecording.SetData(spectrum,0);
			Debug.Log(spectrum[1]);
			*/
		}
		if (microphoneListener.enabled && !recordingState){
			audioRecording=audioRecorder.StopRecording();
		}
		//SavWav.Save("test.wav",audioRecording);
		
		microphoneListener.enabled = recordingState;
		characterListener.enabled = !recordingState;

		if (Input.GetButtonDown("Fire2")){
			playbackSource.clip = audioRecording;
			playbackSource.Play();
		}
	}
}


