using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneControllerVR : MonoBehaviour {
	[SerializeField]
	private AudioListener characterListener;
	[SerializeField]
	private soundCommunication playbackDevice;
	[SerializeField]
	private soundCommunication microphoneCommunication;
	
	[SerializeField]
	private GameObject microphone;
	private SteamVR_TrackedController leftHand;



	private AudioListener microphoneListener;
	private audioRecorder audioRecorder;

	private AudioClip audioRecording;
	private List <AudioClip> playbackSounds = new List<AudioClip>();
	private bool isRecording;

	private float barProgress;
	private float maxRecordingLength;
	private bool holdingRecording;

	[Header("UI")]
	public Image playProgress;
	public Image recordingProgress;
	public Image playButton;

	void Start(){
		leftHand = GetComponent<SteamVR_TrackedController>();
		microphoneListener = microphone.GetComponent<AudioListener>();
		audioRecorder = microphone.GetComponent<audioRecorder>();
		maxRecordingLength = audioRecorder.maxLength;
	}

	void Update () {
		isRecording = leftHand.triggerPressed;
		//setting the audio recorder
		if (!microphoneListener.enabled && isRecording){
			audioRecorder.StartRecording();
			microphoneCommunication.receivedSounds.Clear();
			
			barProgress=0;
		}
		if (microphoneListener.enabled && !isRecording){
			audioRecording=audioRecorder.StopRecording();
			playbackSounds = microphoneCommunication.receivedSounds;
			recordingProgress.enabled=false;
			barProgress=2*maxRecordingLength;
		}
		holdingRecording = audioRecorder.recording != null;

		//updating UI
	
	
			recordingProgress.enabled=isRecording;
			playProgress.enabled=!isRecording && holdingRecording;
			playButton.enabled = holdingRecording;
			
			barProgress+=Time.deltaTime;
			recordingProgress.fillAmount=barProgress/maxRecordingLength;
			if (audioRecording)
			playProgress.fillAmount=2*barProgress/audioRecording.length;

		
		microphoneListener.enabled = isRecording;
		characterListener.enabled = !isRecording;

		if (leftHand.menuPressed && holdingRecording){
			audioRecorder.recording=null;
		}

		if (leftHand.padPressed && !isRecording && holdingRecording){
			barProgress=0;
			playbackDevice.receivedSounds = playbackSounds;
			playbackDevice.PlaySound(audioRecording);
		}
	}
}


