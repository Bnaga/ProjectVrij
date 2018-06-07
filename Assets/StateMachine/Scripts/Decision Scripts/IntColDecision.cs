using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IntColDecision")]
public class IntColDecision : Decision
{
    public override bool Decide(MJStateManager stateManager)
    {
        return CheckInteraction(stateManager);
    }

    bool CheckInteraction(MJStateManager stateManager)
    {
        if(stateManager.isInteracting && !stateManager.coolDown )
        {
            Debug.Log("interaction");
            if (stateManager.interactionTarget.GetComponent<RoleManager>().GetCurrentRole() == 1)
            {
                stateManager.otherIsLeader = true;
            }
            return true;
        }
        return false;
    }
}
