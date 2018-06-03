using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/LeaderInteraction")]
public class LeaderIntDecision : Decision
{

    public override bool Decide(MJStateManager stateManager)
    {
        return CheckCurrentState(stateManager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.isInteracting && stateManager.gameObject.GetComponent<RoleManager>().GetCurrentRole() == 1)
        {
            stateManager.onDestination = true;
            return true;
        }
        else return false;
    }
}
