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
		public AudioClip audio;
		public string meaning;
		[HideInInspector]
		public bool known;
		public bool knownFromStart;
		//[Range(0,10)]
		public int farawaySound;

 }
	
	[Header("Dictionary")]
	public word[] dictionary;


	[Header("Faraway Sounds")]
	public AudioClip[] far;


	 #if UNITY_EDITOR
	 [MenuItem("Assets/Create/Fish Dictionary")]
    public static void MakeScriptableObject()
    {
        ScriptableObjectUtility.CreateAsset<fishDictionary>();
    }
	#endif
	
 

}

 