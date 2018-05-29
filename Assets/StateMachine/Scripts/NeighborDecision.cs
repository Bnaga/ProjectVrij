using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Neighbor")]
public class NeighborDecision : Decision
{
    public override bool Decide(MJStateManager statemanager)
    {
        return CheckCurrentState(statemanager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.curState == 3)
        {
            stateManager.onDestination = true;
            return true;
        }
        else return false;
    }
}
