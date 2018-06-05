using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TalkToBoss")]
public class TalkToBossDecision : Decision
{
    public override bool Decide(MJStateManager stateManager)
    {
        return CheckCurrentState(stateManager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.isInteracting && stateManager.otherIsLeader)
        {
            return true;
        }
        else return false;
    }
}
