using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHIPSScreen : MonoBehaviour {

	public GameObject LayoutElement;
	public fishDictionary dictionary;

	public static AudioClip[] library;
	public Image micImage;

	public CHIPSStorage storage;
	// Use this for initialization
	void OnEnable () {
		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}
		int i = 0;
		storage.Awake();
		storage.ClearAll();
		foreach (fishDictionary.word word in dictionary.dictionary){
			GameObject o = Instantiate(LayoutElement, transform);
			o.GetComponent<CHIPSScreenElement>().Init(i,word);
			i++;
		}
		float h = LayoutElement.GetComponent<RectTransform>().rect.height;
	
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0,h *i);
		Texture2D tex = MicrophoneControllerVR.audioImage;
		micImage.overrideSprite = Sprite.Create (tex, new Rect (0f, 0f, tex.width, tex.height), new Vector2 (0.5f, 0.5f));

	}
	
}
