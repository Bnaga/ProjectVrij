using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneControllerVR : MonoBehaviour {
	[SerializeField]
	private AudioListener characterListener;
	[SerializeField]
	private soundCommunication playbackDevice;
	
	[SerializeField]
	private GameObject microphone;
	
	[SerializeField]
	private SteamVR_TrackedController rightHand;
	private SteamVR_TrackedController leftHand;



	private AudioListener microphoneListener;
	private audioRecorder audioRecorder;
	[SerializeField]
	private soundCommunication microphoneCommunication;
	private AudioClip audioRecording;
	private List <AudioClip> playbackSounds = new List<AudioClip>();
	private bool isRecording;

	void Start(){
		leftHand = GetComponent<SteamVR_TrackedController>();
		microphoneListener = microphone.GetComponent<AudioListener>();
		audioRecorder = microphone.GetComponent<audioRecorder>();
	}

	void Update () {
		isRecording = leftHand.triggerPressed;
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

		if (rightHand.triggerPressed){
			playbackDevice.receivedSounds = playbackSounds;
			playbackDevice.PlaySound(audioRecording);
		}
	}
}


