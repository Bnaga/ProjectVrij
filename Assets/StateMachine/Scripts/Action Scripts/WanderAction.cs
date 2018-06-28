using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : ActionScript
{
    float timer = 0;
    bool onDestination = true;
    Vector3 mojiDestination;
    float wanderTimer = 0;
    public float limit = 20;

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
        wanderTimer += Time.deltaTime;
        onDestination = stateManager.onDestination;
        if (wanderTimer >= limit && !onDestination)
        {
            mojiDestination = RandomNavmeshLocation(0.25f, stateManager);
            stateManager.navMeshAgent.SetDestination(mojiDestination);
            wanderTimer = 0;
        }

        if (onDestination)
        {
            mojiDestination = RandomNavmeshLocation(1.25f, stateManager);
            stateManager.navMeshAgent.SetDestination(mojiDestination);
            stateManager.onDestination = false;
        }


        if (Vector3.Distance(stateManager.transform.position, mojiDestination) < .25f)
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
