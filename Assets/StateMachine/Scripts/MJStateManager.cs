using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MJStateManager : MonoBehaviour {

    public Transform eyes;
    public State currentState;
    public State remainState;
    public bool hide = false;
    public bool inDanger = false;
    public int curState = 0;

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

    public void RandomState()
    {
        int tempState = Random.Range(0, 100);
        if(tempState < 80)
        {
            curState = 1;
        }
        if(tempState >= 80 || tempState <85)
        {
            curState = 2;
        }
        if (tempState >= 85 || tempState < 90)
        {
            curState = 3;
        }
        if (tempState >= 90 || tempState < 95)
        {
            curState = 4;
        }
        if (tempState >= 95 || tempState < 100)
        {
            curState = 5;
        }
    }
}
