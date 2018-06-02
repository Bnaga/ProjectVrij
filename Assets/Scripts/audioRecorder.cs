using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class audioRecorder : MonoBehaviour{


	const int HEADER_SIZE = 44;
	[HideInInspector]
	public bool isRecording;
	private FileStream fileStream;
	private int outputRate = 44100;
    private string filepath;
    private string filename = "recording.wav";
    public AudioClip recording;
    public int maxLength = 2;
    private float recTimer;


    public void StartRecording(){
        isRecording = true;
        filepath = Path.Combine(Application.persistentDataPath, filename);
        fileStream = CreateEmpty(filepath);
        Debug.Log("rec start");
        StartWriting();
        
    }

    public AudioClip StopRecording(){
        if (!isRecording) return recording;
        isRecording = false;
        recTimer = 0;
        WriteHeader();
        recording = WavUtility.ToAudioClip(filepath);
        Debug.Log("rec stop");
        return recording;
    }

	void Update(){
        if (isRecording) recTimer+=Time.deltaTime;
        if (recTimer>maxLength) StopRecording();
	}

	public void OnAudioFilterRead(float[] data, int channels){
		 if(isRecording) ConvertAndWrite(data);
	}

	public void StartWriting(){
		byte emptyByte = new byte();
	
		for(int i = 0; i<HEADER_SIZE; i++) //preparing the header
		{
			fileStream.WriteByte(emptyByte);
		}	

	}

	static FileStream CreateEmpty(string filepath) {
		var fileStream = new FileStream(filepath, FileMode.Create);
	    byte emptyByte = new byte();

	    for(int i = 0; i < HEADER_SIZE; i++) //preparing the header
	    {
	        fileStream.WriteByte(emptyByte);
	    }

		return fileStream;
	}

	void ConvertAndWrite(float[] samples) {


		Int16[] intData = new Int16[samples.Length];
		//converting in 2 float[] steps to Int16[], //then Int16[] to Byte[]

		Byte[] bytesData = new Byte[samples.Length * 2];
		//bytesData array is twice the size of
		//dataSource array because a float converted in Int16 is 2 bytes.

		int rescaleFactor = 32767; //to convert float to Int16

		for (int i = 0; i<samples.Length; i++) {
			intData[i] = (short) (samples[i] * rescaleFactor);
			Byte[] byteArr = new Byte[2];
			byteArr = BitConverter.GetBytes(intData[i]);
			byteArr.CopyTo(bytesData, i * 2);
		}

		fileStream.Write(bytesData, 0, bytesData.Length);
	}

	
	void WriteHeader() {

		fileStream.Seek(0, SeekOrigin.Begin);

		Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
		fileStream.Write(riff, 0, 4);

		Byte[] chunkSize = BitConverter.GetBytes(fileStream.Length - 8);
		fileStream.Write(chunkSize, 0, 4);

		Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
		fileStream.Write(wave, 0, 4);

		Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
		fileStream.Write(fmt, 0, 4);

		Byte[] subChunk1 = BitConverter.GetBytes(16);
		fileStream.Write(subChunk1, 0, 4);

		Byte[] audioFormat = BitConverter.GetBytes(1);
		fileStream.Write(audioFormat, 0, 2);

		Byte[] numChannels = BitConverter.GetBytes(2);
		fileStream.Write(numChannels, 0, 2);

		Byte[] sampleRate = BitConverter.GetBytes(outputRate);
		fileStream.Write(sampleRate, 0, 4);

		Byte[] byteRate = BitConverter.GetBytes(outputRate * 4); // sampleRate * bytesPerSample*number of channels, here 44100*2*2
		fileStream.Write(byteRate, 0, 4);

		UInt16 blockAlign = (ushort) (4);
		fileStream.Write(BitConverter.GetBytes(blockAlign), 0, 2);

		UInt16 bps = 16;
		Byte[] bitsPerSample = BitConverter.GetBytes(bps);
		fileStream.Write(bitsPerSample, 0, 2);

		Byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
		fileStream.Write(datastring, 0, 4);

		Byte[] subChunk2 = BitConverter.GetBytes(fileStream.Length-HEADER_SIZE);
		fileStream.Write(subChunk2, 0, 4);

		fileStream.Close();
	}

    
}