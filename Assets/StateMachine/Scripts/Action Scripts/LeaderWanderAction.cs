using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/LeaderWander")]
public class LeaderWanderAction : ActionScript
{
    float timer = 0;
    bool onDestination = true;
    Vector3 mojiDestination;

    public override void Act(MJStateManager stateManager)
    {
        Wander(stateManager);
        ActTimer(stateManager);
    }

    public Vector3 RandomNavmeshLocation(float radius, MJStateManager stateManager)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        //randomDirection += stateManager.transform.position;
        randomDirection += Vector3.zero;
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
            mojiDestination = RandomNavmeshLocation(0.25f, stateManager);
            stateManager.navMeshAgent.SetDestination(mojiDestination);
            stateManager.onDestination = false;
        }

        if (Vector3.Distance(stateManager.transform.position, mojiDestination) < .075f)
        {
            stateManager.onDestination = true;
        }

    }

    void ActTimer(MJStateManager stateManager)
    {
        stateManager.waitIsOver = false;
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            stateManager.waitIsOver = true;
            timer = 0;
        }
    }
}
