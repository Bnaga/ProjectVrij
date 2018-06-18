using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/BringFood")]
public class BringFoodDecision : Decision
{
    public override bool Decide(MJStateManager stateManager)
    {
        return CheckForage(stateManager);
    }

    public bool CheckForage(MJStateManager stateManager)
    {
        if (stateManager.curState == 17)
        {
            return true;
        }
        else return false;
    }
}
