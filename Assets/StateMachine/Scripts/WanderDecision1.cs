using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Wander")]
public class WanderDecision1 : Decision
{
    public override bool Decide(MJStateManager statemanager)
    {
        return CheckWander(statemanager);
    }

    public bool CheckWander(MJStateManager stateManager)
    {
        if (!stateManager.hide)
        {
            return true;
        }
        else return false;
    }
}
