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

	[HideInInspector]
	public static AudioClip audioRecording;
	public static Texture2D audioImage;
//private List <fishDictionary.word> playbackWords = new List<fishDictionary.word>();
private fishDictionary.word playbackWord;
	private bool isRecording;

	private float barProgress;
	private float maxRecordingLength;
	private bool holdingRecording;

	[Header("UI")]
	public Image playProgress;
	public Image recordingProgress;
	public Image playButton;

	public GameObject Menu;
	private bool menuActive;
	public VRTK.VRTK_Pointer PointerScript;

	void Start(){
		leftHand = GetComponent<SteamVR_TrackedController>();
		microphoneListener = microphone.GetComponent<AudioListener>();
		audioRecorder = microphone.GetComponent<audioRecorder>();
		maxRecordingLength = audioRecorder.maxLength;
	}

	void Update () {
		isRecording = leftHand.triggerPressed;
		//setting the audio recorder
		if (!microphoneListener.enabled && isRecording && !menuActive){
			audioRecorder.StartRecording();
			microphoneCommunication.Clear();
			
			barProgress=0;
		}
		if (microphoneListener.enabled && !isRecording){
			audioRecording=audioRecorder.StopRecording();
			//audioImage = WaveFormImage.RenderWaveForm(audioRecording,Color.red);
			playbackWord = microphoneCommunication.nearestReceived();
			recordingProgress.enabled=false;
			barProgress=2*maxRecordingLength;
			if (playbackWord != null){ 
				knownWordManager.checkRecording(playbackWord);
			}else{
				knownWordManager.textBalloon(transform,"Nothing recorded");
			}
		}
		holdingRecording = audioRecorder.recording != null;
		Debug.Log(playbackWord);

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

		if (leftHand.menuPressed && barProgress>.3f){
			return;
			barProgress=0;
			menuActive = !Menu.activeInHierarchy;
			Menu.SetActive(menuActive);
			//PointerScript.Toggle(a);
			playButton.enabled = menuActive;
			recordingProgress.enabled = menuActive;


		}

		if (leftHand.padPressed && !isRecording && holdingRecording && !menuActive){
			barProgress=0;
			playbackDevice.playbackWord = playbackWord;
			playbackDevice.PlaySound(audioRecording);
			if (playbackWord != null) knownWordManager.wordBalloon(transform,playbackWord);
		}
	}
	
	
}


