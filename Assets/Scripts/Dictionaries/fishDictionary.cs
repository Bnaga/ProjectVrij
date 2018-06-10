using UnityEngine;
using System.Collections;
using System;
 #if UNITY_EDITOR
using UnityEditor;
#endif
[Serializable]
	public class fishDictionary : ScriptableObject {
	
	[System.Serializable]
	public class word {
		public string Name;
		public string meaning;
		public AudioClip[] audio;	
		[Range(0,10)]
		public int farawaySound;	
		[HideInInspector]
		public bool known;
		public bool knownFromStart;
		
		

 }
	
	[Header("Dictionary")]
	public word[] dictionary;


	[Header("Faraway Sounds")]
	public AudioClip[] far;
	public AudioClip[] test;


	 #if UNITY_EDITOR
	 [MenuItem("Assets/Create/Fish Dictionary")]
    public static void MakeScriptableObject()
    {
        ScriptableObjectUtility.CreateAsset<fishDictionary>();
    }
	#endif
	
 

}

 