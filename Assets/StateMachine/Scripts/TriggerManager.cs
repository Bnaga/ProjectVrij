using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    MJStateManager stateManager;
	// Use this for initialization
	void Start ()
    {
        stateManager = this.gameObject.GetComponent<MJStateManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mojili")
        {
            Debug.Log("trigger" + other.transform.parent.gameObject.name);
            if (stateManager.interactionTarget == null && other.GetComponent<MJStateManager>().interactionTarget == null)
            {
                other.transform.parent.gameObject.GetComponent<MJStateManager>().isInteracting = true;
                stateManager.isInteracting = true;
                other.transform.parent.gameObject.GetComponent<MJStateManager>().interactionTarget = this.gameObject;
                stateManager.interactionTarget = other.gameObject;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == stateManager.interactionTarget.name)
        {
            other.transform.parent.gameObject.GetComponent<MJStateManager>().isInteracting = false;
            stateManager.isInteracting = false;
            other.transform.parent.gameObject.GetComponent<MJStateManager>().interactionTarget = null;
            stateManager.interactionTarget = null;
        }
    }
}
