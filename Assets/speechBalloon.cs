using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class speechBalloon : MonoBehaviour {

	public float lifetime;
	private float timer;
	private fishDictionary.word word;
	
	// Update is called once per frame
	public void init(fishDictionary.word initword){
		word = initword;
		transform.rotation = Random.rotation;
		string text = word.meaning;
		if (!word.known) text = "???????";
		GetComponent<TextMeshPro>().SetText(text);

	}
	
	void Update () {
		timer += Time.deltaTime;
		if (timer>lifetime) Destroy(gameObject);
	}
	
}
