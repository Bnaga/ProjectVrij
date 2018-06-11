 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveFormImage : MonoBehaviour {


	public static Texture2D RenderWaveForm(AudioClip clip, Color col){
		return PaintWaveformSpectrum (GetWaveform (clip, 400), 400, col);
	}
	public static float[] GetWaveform (AudioClip audio, int resolution) {
		resolution = audio.frequency / resolution;
 
        float[] samples = new float[audio.samples*audio.channels];
		float[] waveForm = new float[(samples.Length/resolution)];
        audio.GetData(samples,0);
 
        
 
        for (int i = 0; i < waveForm.Length; i++)
        {
            waveForm[i] = 0;
 
            for(int ii = 0; ii<resolution; ii++)
            {
                waveForm[i] += Mathf.Abs(samples[(i * resolution) + ii]);
            }          
 
        waveForm[i] /= resolution;
		}
		return waveForm;
	}

     public static Texture2D PaintWaveformSpectrum(float[] waveform, int height, Color c) {
         Texture2D tex = new Texture2D (waveform.Length, height, TextureFormat.RGBA32, false);
 
         for (int x = 0; x < waveform.Length; x++) {
             for (int y = 0; y <= waveform [x] * (float)height / 2f; y++) {
                 tex.SetPixel (x, (height / 2) + y, c);
                 tex.SetPixel (x, (height / 2) - y, c);
             }
         }
         tex.Apply ();
 
         return tex;
     }
}
 