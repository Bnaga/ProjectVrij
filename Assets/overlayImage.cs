using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class overlayImage : MonoBehaviour {

	public static overlayImage self;
	private static Image overlay;
	public static int currentAlpha;
	// Use this for initialization
	void Awake () {
		overlay = GetComponent<Image>();
		currentAlpha = Mathf.FloorToInt(overlay.color.a*255);
	}
	
	// Update is called once per frame
	void Update () {
		self = this;
	}

	public static void setAlpha(int i){
		Color c = overlay.color;
		c.a = i/255f;
		currentAlpha = i;
		overlay.color = c;
	}
}
