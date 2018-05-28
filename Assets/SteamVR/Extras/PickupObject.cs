//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupObject : MonoBehaviour
{
	public Rigidbody attachPoint;
	public float grabRadius = 1f;
	public LayerMask grabMask;

	LineRenderer LineRenderer;
	SteamVR_TrackedObject trackedObj;
	FixedJoint joint;
    Rigidbody targetrb;

	[SerializeField]
	GameObject heldObject;

	private Rigidbody ownrb;
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		LineRenderer = GetComponent<LineRenderer>();
		joint = gameObject.AddComponent<FixedJoint>();
		ownrb = GetComponent<Rigidbody>();
	}

	bool checkHit(Rigidbody rb){

		return rb != null && rb!= ownrb;
	}


	void FixedUpdate()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (heldObject == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			RaycastHit[] hits;
			hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 1f);
            transform.localScale = new Vector3(Random.Range(.9f, 1.1f), Random.Range(.9f, 1.1f), Random.Range(.9f, 1.1f));
			if (hits.Length > 0)
			{
				int closestHit = 0;
				bool multiple = false;
				for (int i = 0; i < hits.Length; i++){
					if ( targetrb != null && targetrb != ownrb && (hits[i].distance < hits[closestHit].distance || !multiple)){
						closestHit = i;
						multiple = true;
					}                  
				}
				

				targetrb = hits[closestHit].rigidbody;
				if (targetrb != null && targetrb != ownrb){
					Debug.Log("GRABBED:" + hits[closestHit].transform.gameObject.name);
					LineRenderer.SetPosition(0,transform.position);
					LineRenderer.SetPosition(1,hits[closestHit].point);
					heldObject = hits[closestHit].transform.gameObject;
					targetrb.isKinematic =true;
					heldObject.transform.position = attachPoint.transform.position;
					joint.connectedBody = targetrb;
					heldObject.transform.position=transform.position;
				}
			}
		}
		else if (heldObject != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{

			var rigidbody = heldObject.GetComponent<Rigidbody>();
			//Object.DestroyImmediate(joint);
			//joint = null;
			heldObject = null;
			joint.connectedBody=null;
			rigidbody.isKinematic=false;

			//Object.Destroy(go, 15.0f);

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
