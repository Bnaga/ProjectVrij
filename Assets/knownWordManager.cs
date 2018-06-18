using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class knownWordManager : MonoBehaviour {

	public GameObject speechBalloon;
	public GameObject speechParticles;
	public Material alertMaterial;
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

	public static void checkRecording(fishDictionary.word word){
		o = Instantiate(self.speechBalloon,self.transform);
		if (!word.known){
			o.GetComponent<speechBalloon>().init("NEW SOUND DISCOVERED!");
		} else{
			o.GetComponent<speechBalloon>().initWord(word);
		}
	}
	

	public static void wordBalloon(Transform t, fishDictionary.word word ){
		if (!self){
			Debug.Log("no self knownwordmanager");
			return;
		};
		Instantiate(self.speechParticles,t);
		if (!word.known) return;
		o = Instantiate(self.speechBalloon, t);
		o.GetComponent<speechBalloon>().initWord(word);
		setGlobScale(o.transform,Vector3.one);
		Vector3 r = Random.insideUnitSphere/5;
		r.y = Mathf.Abs(r.y) + .1f;
		o.transform.position += r;
	}

	public static void textBalloon(Transform t, string text){
		Instantiate(self.speechParticles,t);
		o = Instantiate(self.speechBalloon, t);
		o.GetComponent<speechBalloon>().init(text);
		setGlobScale(o.transform,Vector3.one);
		Vector3 r = Random.insideUnitSphere/5;
		r.y = Mathf.Abs(r.y) + .1f;
		o.transform.position += r;
	}

	public static void alerted(Vector3 location){
		o = Instantiate(self.speechParticles,location, Quaternion.identity);
		o.GetComponent<ParticleSystemRenderer>().material = self.alertMaterial;

	}

	 public static void setGlobScale ( Transform transform, Vector3 globalScale)
 {
     transform.localScale = Vector3.one;
     transform.localScale = new Vector3 (globalScale.x/transform.lossyScale.x, globalScale.y/transform.lossyScale.y, globalScale.z/transform.lossyScale.z);
 }

	
}
