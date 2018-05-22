using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hide")]
public class HideDecision : Decision
{
    public override bool Decide(MJStateManager stateManager)
    {
        return InHiding(stateManager);
    }

    public bool InHiding(MJStateManager stateManager)
    {
        if(stateManager.hide)
        {
            return true;
        }
        return false;
    }
}
