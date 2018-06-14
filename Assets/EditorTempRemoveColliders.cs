using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorTempRemoveColliders : MonoBehaviour 
{

	// editor only temporary bug fix that looks for mesh colliders created by a Cloth Component and deletes them, leaving only the first one found.
	#if (UNITY_EDITOR)

	public int count;

	private void Update()
	{
		MeshCollider[] colliders = GetComponents<MeshCollider>();

		for (int i = 1; i < colliders.Length; i++)       
		{
			count++;
			print("Destroyed " + colliders[i] + " as " + count + " destroyed.");
			DestroyImmediate(colliders[i]);                
		}

	}
	#endif

}