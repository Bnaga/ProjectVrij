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
		public AudioClip audio;
		public string meaning;
		[HideInInspector]
		public bool known;
		public bool knownFromStart;
 }
	
	[Header("Dictionary")]
	public word[] dictionary;


	[Header("General")]
	public float talkRate;
	 #if UNITY_EDITOR
	 [MenuItem("Assets/Create/Fish Dictionary")]
    public static void MakeScriptableObject()
    {
        ScriptableObjectUtility.CreateAsset<fishDictionary>();
    }
	#endif
	
 

}

 