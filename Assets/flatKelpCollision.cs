using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flatKelpCollision : MonoBehaviour {

	public static CapsuleCollider left;
	public static CapsuleCollider right;

	public CapsuleCollider localLeft;
	public  CapsuleCollider localRight;

	private Cloth cloth;
	private bool retry = true;
	
	// Update is called once per frame

	void Start(){
		if (!left && ! right){
			left = localLeft;
			right=localRight;
		}else{
			retry=false;
		}
		 
		cloth = GetComponent<Cloth>();
		if (!cloth) return;
		cloth.capsuleColliders = new CapsuleCollider[]{left,right};
	}
	
	void Update(){
		if (retry){ Start();

		}

	}
}
