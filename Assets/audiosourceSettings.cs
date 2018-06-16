using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class audiosourceSettings : MonoBehaviour {

	public static AudioSource source;

	// Use this for initialization
	void Awake () {
		if (!source) source = GetComponent<AudioSource>();
	}

	public static AudioSource CopyComponent(GameObject destination)
	{
		AudioSource copy = destination.AddComponent(typeof(AudioSource)) as AudioSource;
		// Copied fields can be restricted with BindingFlags
		System.Reflection.FieldInfo[] fields = typeof(AudioSource).GetFields(); 
		foreach (System.Reflection.FieldInfo field in fields)
		{
			field.SetValue(copy, field.GetValue(source));
		}
		return copy;
	}

}
