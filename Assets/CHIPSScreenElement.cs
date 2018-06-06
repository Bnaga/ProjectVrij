using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHIPSScreenElement : MonoBehaviour {

	public int id;

	public Text humanSpeak;
	public Text mojiliSpeak;
	public fishDictionary.word word;
	
	public void Init(int i, fishDictionary.word w){
		word = w;
		id = i;

		gameObject.name = word.meaning;
		humanSpeak.text = word.meaning;
		if (CHIPSStorage.storage[i]){
			mojiliSpeak.text= "FILLED";
		}else{
			mojiliSpeak.text = "???";
		}

	}
	public void OpenMenu(){
		CHIPSStorage.self.Init(id);
	}
}
