using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggermanager2 : MonoBehaviour 
{
MJStateManager stateManager;
	// Use this for initialization
	void Start ()
    {
        stateManager = gameObject.GetComponent<MJStateManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mojili")
        {
            Debug.Log("trigger" + other.name);
            if (stateManager.interactionTarget == null && other.gameObject.GetComponent<MJStateManager>().interactionTarget == null)
            {
                other.gameObject.GetComponent<MJStateManager>().isInteracting = true;
                stateManager.isInteracting = true;
                other.gameObject.GetComponent<MJStateManager>().interactionTarget = this.gameObject;
                stateManager.interactionTarget = other.gameObject;
                stateManager.onDestination = true;
                other.GetComponent<MJStateManager>().navMeshAgent.SetDestination(other.transform.position);
                other.GetComponent<MJStateManager>().onDestination = true;
                other.GetComponent<MJStateManager>().interactionTarget = this.gameObject;
                stateManager.isInteractor = true;
                other.gameObject.GetComponent<MJStateManager>().isInteractee = true;
            }

        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Mojili")
        {
            if (other.gameObject.name == stateManager.interactionTarget.name)
            {
                other.gameObject.GetComponent<MJStateManager>().isInteracting = false;
                stateManager.isInteracting = false;
                other.gameObject.GetComponent<MJStateManager>().interactionTarget = null;
                stateManager.interactionTarget = null;
                stateManager.isInteractor = false;
                other.gameObject.GetComponent<MJStateManager>().isInteractee = false;
            }
        }

    }
    
}
