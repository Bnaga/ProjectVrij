using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knownWordManager : MonoBehaviour {

	public GameObject speechBalloon;
	public GameObject speechParticles;
	public static knownWordManager self;
	public fishDictionary[] dictionaries;
	private static GameObject o;

	void Start(){
		self = this;
		foreach (fishDictionary dict in dictionaries){
			foreach (fishDictionary.word w in dict.dictionary){
				w.known = w.knownFromStart;
			}
		}
	}

	public static void checkRecording(List<fishDictionary.word> words){
		if (words.Count<1) return;
		fishDictionary.word word = words[0];
		o = Instantiate(self.speechBalloon,self.transform);
		if (!word.known){
			o.GetComponent<speechBalloon>().init("NEW SOUND DISCOVERED!");
		} else{
			o.GetComponent<speechBalloon>().initWord(word);
		}
	}
	

	public static void wordBalloon(Vector3 location, fishDictionary.word word ){
		if (!word.known) return;
		o = Instantiate(self.speechBalloon, location, Quaternion.identity);
		o.GetComponent<speechBalloon>().initWord(word);
	}
}
