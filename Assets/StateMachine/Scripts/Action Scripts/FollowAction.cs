using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/FollowAction")]
public class FollowAction : ActionScript
{
    public override void Act(MJStateManager stateManager)
    {
        FollowTarget(stateManager);
    }

    void FollowTarget(MJStateManager stateManager)
    {
        stateManager.navMeshAgent.SetDestination(stateManager.followTarget.transform.position);
        stateManager.StartInteractiontimer();
    }
}
