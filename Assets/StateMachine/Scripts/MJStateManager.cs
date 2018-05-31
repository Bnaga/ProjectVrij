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
    public int tempState = 0;
    public bool onDestination = true;
    public bool hasFood = false;

    [HideInInspector] public NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Awake ()
    {
        curState = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        onDestination = true;
        //navMeshAgent.destination = Vector3.zero;
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
        tempState = Random.Range(1, 101);
        if(tempState < 80)
        {
            curState = 1;
        }
        if(tempState >= 80 && tempState <85)
        {
            curState = 2;
        }
        if (tempState >= 85 && tempState < 90)
        {
            curState = 3;
        }
        if (tempState >= 90 && tempState < 95)
        {
            curState = 4;
        }
        if (tempState >= 95 && tempState <= 100)
        {
            curState = 5;
        }
    }

    public void RandomSoldierState()
    {
        tempState = Random.Range(0, 10);
        if (tempState < 9)
        {
            curState = 6;
        }
        if (tempState == 9)
        {
            curState = 7;
        }
    }

    public void RandomFarmerState()
    {
        tempState = Random.Range(0, 2);
        if (tempState == 0)
        {
            curState = 8;
        }
        if (tempState == 1)
        {
            RandomState();
        }
    }
}
