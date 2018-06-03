using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Explore")]
public class ExploreDecision : Decision
{
    public override bool Decide(MJStateManager statemanager)
    {
        return CheckCurrentState(statemanager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.curState == 4)
        {
            stateManager.onDestination = true;
            return true;
        }
        else return false;
    }
}
