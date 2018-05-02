using UnityEngine; 
using System.Collections;

public class godrayRotation : MonoBehaviour {

public float rotationSpeed = 100.0f; 


// Update is called once per frame 
	void Update () {
		transform.Rotate(0,Time.deltaTime * rotationSpeed, 0, Space.World);
	}
}