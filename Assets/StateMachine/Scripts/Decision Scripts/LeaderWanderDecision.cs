using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/LeaderWander")]
public class LeaderWanderDecision : Decision
{
    public override bool Decide(MJStateManager statemanager)
    {
        return CheckWander(statemanager);
    }

    public bool CheckWander(MJStateManager stateManager)
    {
        if (stateManager.curState == 6 )
        {
            return true;
        }
        else return false;
    }
}
