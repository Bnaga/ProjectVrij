using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/SendToLeader")]
public class SendToLeaderDecision : Decision
{

    public override bool Decide(MJStateManager stateManager)
    {
        return CheckCurrentState(stateManager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.curState == 12)
        {
            stateManager.onDestination = true;
            return true;
        }
        else return false;
    }
}
