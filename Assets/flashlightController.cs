using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightController : MonoBehaviour {

	// Use this for initialization
	public Light light;
	private SteamVR_TrackedController control;
	void Start () {
		control = GetComponent<SteamVR_TrackedController>();
	}
	
	// Update is called once per frame
	void Update () {
		light.enabled = control.triggerPressed;
		
	}
}
