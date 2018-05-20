using UnityEngine;
using System.Collections;
using System;
using UnityEditor;
[Serializable]
	public class fishDictionary : ScriptableObject {
	
	[System.Serializable]
	public struct word {
		public AudioClip audio;
		public string meaning;
		[HideInInspector]
		public bool known;
 }
	
	[Header("Dictionary")]
	
	public word[] dictionary;
	
	[Header("General")]
	public float talkRate;

	 [MenuItem("Assets/Create/Fish Dictionary")]
    public static void MakeScriptableObject()
    {
        ScriptableObjectUtility.CreateAsset<fishDictionary>();
    }

	
 

}

 