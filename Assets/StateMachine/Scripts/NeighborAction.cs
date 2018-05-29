using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Neighbor")]
public class NeighborAction : ActionScript
{
    private GameObject[] mojili;
    private float friendDistance = 100;
    private Vector3 target;
    bool onDestination = true;
    Vector3 mojiDestination;

    public override void Act(MJStateManager stateManager)
    {
        GoToFriend(stateManager);
    }

    private void GoToFriend(MJStateManager stateManager)
    {
        onDestination = stateManager.onDestination;
        if (onDestination)
        {
            target = GetTarget(stateManager);
            stateManager.navMeshAgent.SetDestination(target);
            stateManager.onDestination = false;
            
        }

        if (Vector3.Distance(stateManager.transform.position, target) <= .5f)
        {
            stateManager.onDestination = true;
            stateManager.hide = true;
        }

    }

    private Vector3 GetTarget(MJStateManager stateManager)
    {
        friendDistance = 100;
        mojili = GameObject.FindGameObjectsWithTag("Mojili");
        Vector3 currentTarget = Vector3.zero;
        Debug.Log(mojili.Length);
        for (int i = 0; i < mojili.Length; i++)
        {

            float tempfriendDistance = Vector3.Distance(stateManager.transform.position, mojili[i].transform.position);
            if (tempfriendDistance <= friendDistance)
            {
                friendDistance = tempfriendDistance;
                currentTarget = mojili[i].transform.position;
            }
        }
        return currentTarget;
    }
}
