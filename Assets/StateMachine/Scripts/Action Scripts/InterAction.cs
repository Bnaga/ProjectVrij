using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/InterAction")]
public class InterAction : ActionScript
{
    Vector3 averagePos = Vector3.zero;
    public override void Act(MJStateManager stateManager)
    {
        MoveToAvg(stateManager);
        stateManager.StartInteractiontimer();
    }

    void MoveToAvg(MJStateManager stateManager)
    {
        if (stateManager.onDestination && stateManager.interactionTarget != null)
        {
            averagePos = (stateManager.gameObject.transform.position + stateManager.interactionTarget.transform.position) / 2;
            //Debug.Log(averagePos);
            stateManager.navMeshAgent.SetDestination(averagePos);
            stateManager.onDestination = false;
            stateManager.onIntDestination = false;
        }
        if (stateManager.interactionTarget != null)
        {
            if (Vector3.Distance(stateManager.gameObject.transform.position, averagePos) <= 0.2f && Vector3.Distance(stateManager.interactionTarget.transform.position, averagePos) <= 0.2f)
            {
                stateManager.onDestination = true;
                stateManager.onIntDestination = true;
            }
        }



    }
}
