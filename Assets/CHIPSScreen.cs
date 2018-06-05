using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHIPSScreen : MonoBehaviour {

	public GameObject LayoutElement;
	public fishDictionary dictionary;

	public static AudioClip[] library;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}

		foreach (fishDictionary.word word in dictionary.dictionary){
			GameObject o = Instantiate(LayoutElement, transform);
			o.name = word.meaning;
			GameObject meaning = GameObject.Find(o.name + "/humanSpeak/Text");
			meaning.GetComponent<Text>().text = word.meaning;
		}
	}
}
