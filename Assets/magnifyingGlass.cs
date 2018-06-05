using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class magnifyingGlass : MonoBehaviour {

	
	public Camera cam;
	public Camera mainCam;
	public float magnification = 2;
	public Quaternion rotationOffset;

	private Quaternion parentRot;


	void Awake(){
		if (!mainCam) mainCam = Camera.main;
	}

	void FixedUpdate () {
		//Vector3 parent = transform.eulerAngles;
		//transform.localRotation = Quaternion.Euler(0,-parent.y,0);

		float d = Mathf.Abs(Vector3.Magnitude(mainCam.transform.position-transform.position));
		cam.fieldOfView = Mathf.Clamp(d*magnification,7,90);
		cam.transform.LookAt(mainCam.transform);
		cam.transform.rotation *= rotationOffset * Quaternion.Euler(0,-transform.eulerAngles.y,-transform.eulerAngles.z);
		//cam.transform.rotation = mainCam.transform.rotation;

		Debug.DrawLine(cam.transform.position, cam.transform.position + cam.transform.forward);

		/*
		Debug.DrawLine(transform.position,transform.position - magnification * transform.up);
		RaycastHit hit;
		float distance = magnification;
		if (Physics.Raycast(transform.position, transform.TransformDirection(-transform.up), out hit, magnification)){
			distance = Vector3.Magnitude(transform.position-hit.point);
			Debug.DrawLine(transform.position,transform.position + magnification * transform.up);
		}
		cameraObject.transform.position = transform.position - transform.up * distance;
		*/
		
	}
}
