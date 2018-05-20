using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MJStateManager : MonoBehaviour {

    public Transform eyes;
    public State currentState;
    public State remainState;

    [HideInInspector] public NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Awake ()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
	}

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null )
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, 0.1f);
        }
    }

    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
