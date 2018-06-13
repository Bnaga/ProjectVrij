using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hide")]
public class HideDecision : Decision
{
    float testTimer = 0;
    float endTimer = 3;

    public override bool Decide(MJStateManager stateManager)
    {
        return InHiding(stateManager);
    }

    public bool InHiding(MJStateManager stateManager)
    {
        testTimer += Time.deltaTime;
        if (stateManager.hide && testTimer >= endTimer)
        {
            testTimer = 0;
            stateManager.curState = 0;
            return true;
        }
        return false;
    }
}
