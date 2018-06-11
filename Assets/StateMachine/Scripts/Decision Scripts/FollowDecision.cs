using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Follow")]
public class FollowDecision : Decision
{
    public override bool Decide(MJStateManager stateManager)
    {
        return CheckState(stateManager);
    }

    bool CheckState(MJStateManager stateManager)
    {
        if (stateManager.curState == 14)
        {
            return true;
        }
        else return false;
    }
}
