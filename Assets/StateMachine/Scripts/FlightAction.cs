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
    //bool arrived = false;

    public override void Act(MJStateManager stateManager)
    {
        throw new NotImplementedException();
    }

    private void Hide(MJStateManager stateManager)
    {
        if (onDestination)
        {
            target = GetTarget(stateManager);
            stateManager.navMeshAgent.SetDestination(target);
            onDestination = false;
        }

        if (Vector3.Distance(stateManager.transform.position, target) < 4)
        {
            stateManager.hide = true;
        }

    }

    private Vector3 GetTarget(MJStateManager stateManager)
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        Vector3 currentTarget = Vector3.zero;
        for (int i = 0; i < houses.Length; i++)
        {
            float temphouseDistance = Vector3.Distance(stateManager.transform.position, houses[i].transform.position);
            if (temphouseDistance < houseDistance)
            {
                houseDistance = temphouseDistance;
                currentTarget = stateManager.transform.position;
            }
        }
        return currentTarget;
    }
}

