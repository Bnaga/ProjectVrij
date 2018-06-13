using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class speechBalloon : MonoBehaviour {

	public float lifetime;
	private float timer;
	private fishDictionary.word word;
	
	// Update is called once per frame
	public void initWord(fishDictionary.word initword){
		word = initword;
		
		string text = word.meaning;
		if (!word.known) text = "???????";
		init(text);
		

	}

	public void init(string text){
		transform.rotation = Random.rotation;
		GetComponent<TextMeshPro>().SetText(text);
	}


	
	void Update () {
		timer += Time.deltaTime;
		if (timer>lifetime) Destroy(gameObject);
	}
	
}
