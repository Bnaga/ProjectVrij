﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : ActionScript
{

    bool onDestination = true;
    Vector3 mojiDestination;

    public override void Act(MJStateManager stateManager)
    {
        Wander(stateManager);

    }

    public Vector3 RandomNavmeshLocation(float radius, MJStateManager stateManager)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        randomDirection += stateManager.transform.position;
        UnityEngine.AI.NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private void Wander(MJStateManager stateManager)
    {
        onDestination = stateManager.onDestination;
        if (onDestination)
        {
            Debug.Log("test6");
            mojiDestination = RandomNavmeshLocation(.75f, stateManager);
            stateManager.navMeshAgent.SetDestination(mojiDestination);
            stateManager.onDestination = false;
        }

        if (Vector3.Distance(stateManager.transform.position, mojiDestination) < .25f)
        {
            stateManager.onDestination = true;
        }

    }

}
