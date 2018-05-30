using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/GoHome")]
public class GoHomeAction : ActionScript
{
    private GameObject[] houses;
    private float houseDistance = 100;
    private Vector3 target;
    bool onDestination = true;
    Vector3 mojiDestination;

    public override void Act(MJStateManager stateManager)
    {
        GoHome(stateManager);
    }

    private void GoHome(MJStateManager stateManager)
    {
        onDestination = stateManager.onDestination;
        if (onDestination)
        {
            target = GetTarget(stateManager);
            stateManager.navMeshAgent.SetDestination(target);
            stateManager.onDestination = false;
        }

        if (Vector3.Distance(stateManager.transform.position, target) <= .1f)
        {
            stateManager.onDestination = true;
        }

    }

    private Vector3 GetTarget(MJStateManager stateManager)
    {
        houseDistance = 100;
        houses = GameObject.FindGameObjectsWithTag("House");
        Vector3 currentTarget = Vector3.zero;
        //Debug.Log(houses.Length);
        for (int i = 0; i < houses.Length; i++)
        {

            float temphouseDistance = Vector3.Distance(stateManager.transform.position, houses[i].transform.position);
            if (temphouseDistance <= houseDistance)
            {
                houseDistance = temphouseDistance;
                //Debug.Log(houseDistance);
                currentTarget = new Vector3( houses[i].transform.position.x, 0, houses[i].transform.position.z);
            }
        }
        return currentTarget;
    }
}
