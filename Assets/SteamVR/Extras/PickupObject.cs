//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupObject : MonoBehaviour
{
	public GameObject prefab;
	public Rigidbody attachPoint;
	public float grabRadius = 1f;
	public LayerMask grabMask;

	SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}



	void FixedUpdate()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			RaycastHit[] hits;
			hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);
	
			if (hits.Length > 0)
			{
				int closestHit = 0;
				for (int i = 0; i < hits.Length; i++){
					if (hits[i].distance < hits[closestHit].distance) closestHit = i;                  
				}
				Rigidbody targetrb = hits[closestHit].rigidbody;
				if (targetrb){
					var go = hits[closestHit].transform.gameObject;
					targetrb.isKinematic =true;
					go.transform.position = attachPoint.transform.position;

					joint = go.AddComponent<FixedJoint>();
					joint.connectedBody = attachPoint;
				}
			}
		}
		else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			var go = joint.gameObject;
			var rigidbody = go.GetComponent<Rigidbody>();
			Object.DestroyImmediate(joint);
			joint = null;
			Object.Destroy(go, 15.0f);

			// We should probably apply the offset between trackedObj.transform.position
			// and device.transform.pos to insert into the physics sim at the correct
			// location, however, we would then want to predict ahead the visual representation
			// by the same amount we are predicting our render poses.

			var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
			if (origin != null)
			{
				rigidbody.velocity = origin.TransformVector(device.velocity);
				rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
			}
			else
			{
				rigidbody.velocity = device.velocity;
				rigidbody.angularVelocity = device.angularVelocity;
			}

			rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
		}
	}
}
