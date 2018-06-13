using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosourceSettings : MonoBehaviour {

	public static AudioSource source;

	// Use this for initialization
	void Awake () {
		if (!source) source = GetComponent<AudioSource>();
	}
}
