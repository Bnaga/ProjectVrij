using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Forage")]
public class ForageDecision : Decision
{
    public override bool Decide(MJStateManager stateManager)
    {
        return CheckForage(stateManager);
    }

    public bool CheckForage(MJStateManager stateManager)
    {
        if (stateManager.curState == 16)
        {
            return true;
        }
        else return false;
    }
}
