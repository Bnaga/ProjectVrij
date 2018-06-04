using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/CheckForBoss")]
public class CheckLeaderDecision : Decision
{

    public override bool Decide(MJStateManager stateManager)
    {
        return CheckCurrentState(stateManager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.otherIsLeader)
        {
            stateManager.onDestination = true;
            return true;
        }
        else return false;
    }
}
