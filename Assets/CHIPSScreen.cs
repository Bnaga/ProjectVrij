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
		int i = 0;
		foreach (fishDictionary.word word in dictionary.dictionary){
			GameObject o = Instantiate(LayoutElement, transform);
			o.name = word.meaning;
			Text text = GameObject.Find(o.name + "/humanSpeak/Text").GetComponent<Text>();
			text.text = word.meaning;
			GameObject mojili = GameObject.Find(o.name + "/mojiliSpeak/Text");
			text = mojili.GetComponent<Text>();
			mojili.GetComponent<Button>().onClick.AddListener(delegate {InitUI(i); });
			if (CHIPSStorage.storage[i]){
				text.text= "FILLED";
			}else{
				text.text = "???";
			}

			i++;
		}
	}

	void InitUI(int i){
		CHIPSStorage.self.Init(i);
	}
}
