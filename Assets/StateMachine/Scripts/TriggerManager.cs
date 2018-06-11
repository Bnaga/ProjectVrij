using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    MJStateManager stateManager;
	// Use this for initialization
	void Start ()
    {
        stateManager = this.transform.parent.gameObject.GetComponent<MJStateManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mojili")
        {
            Debug.Log("trigger" + other.transform.parent.gameObject.name);
            if (stateManager.interactionTarget == null && other.transform.parent.gameObject.GetComponent<MJStateManager>().interactionTarget == null)
            {
                other.transform.parent.gameObject.GetComponent<MJStateManager>().isInteracting = true;
                stateManager.isInteracting = true;
                other.transform.parent.gameObject.GetComponent<MJStateManager>().interactionTarget = this.transform.parent.gameObject;
                stateManager.interactionTarget = other.transform.parent.gameObject;
                stateManager.onDestination = true;
                other.transform.parent.gameObject.GetComponent<MJStateManager>().navMeshAgent.SetDestination(other.transform.position);
                other.transform.parent.gameObject.GetComponent<MJStateManager>().onDestination = true;
                other.transform.parent.gameObject.GetComponent<MJStateManager>().interactionTarget = this.transform.parent.gameObject.gameObject;
                stateManager.isInteractor = true;
                other.transform.parent.gameObject.GetComponent<MJStateManager>().isInteractee = true;
            }

        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.gameObject.name == stateManager.interactionTarget.name)
        {
            other.transform.parent.gameObject.GetComponent<MJStateManager>().isInteracting = false;
            stateManager.isInteracting = false;
            other.transform.parent.gameObject.GetComponent<MJStateManager>().interactionTarget = null;
            stateManager.interactionTarget = null;
        }
    }
    */
}
