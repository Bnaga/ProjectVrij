using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/GoHome")]
public class GoHomeDecision : Decision
{
    public override bool Decide(MJStateManager statemanager)
    {
        return CheckCurrentState(statemanager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.curState == 2)
        {
            stateManager.onDestination = true;
            return true;
        }
        else return false;
    }
}
