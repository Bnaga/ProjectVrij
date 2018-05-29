using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Flight")]
public class FlightAction : ActionScript
{
    private GameObject[] houses;
    private float houseDistance = 100;
    private Vector3 target;
    bool onDestination = true;
    Vector3 mojiDestination;
    //bool arrived = false;

    public override void Act(MJStateManager stateManager)
    {
        Hide(stateManager);
    }

    private void Hide(MJStateManager stateManager)
    {
        onDestination = stateManager.onDestination;
        if (onDestination)
        {
            target = GetTarget(stateManager);
            stateManager.navMeshAgent.SetDestination(target);
            stateManager.onDestination = false;
            Debug.Log("test");
        }

        if (Vector3.Distance(stateManager.transform.position, target) <= .25f)
        {
            stateManager.onDestination = true;
            stateManager.hide = true;
        }

    }

    private Vector3 GetTarget(MJStateManager stateManager)
    {
        houseDistance = 100;
        houses = GameObject.FindGameObjectsWithTag("House");
        Vector3 currentTarget = Vector3.zero;
        Debug.Log(houses.Length);
        for (int i = 0; i < houses.Length; i++)
        {
            
            float temphouseDistance = Vector3.Distance(stateManager.transform.position, houses[i].transform.position);
            if (temphouseDistance <= houseDistance)
            {
                houseDistance = temphouseDistance;
                Debug.Log(houseDistance);
                //currentTarget = stateManager.transform.position;
                currentTarget = houses[i].transform.position;
                Debug.Log(houses[i].name);
            }
        }
        return currentTarget;
    }
}

