using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName ="PluggableAI/Decisions/Idle")]
public class IdleDecision : Decision {

    float testTimer = 0;
    float endTimer = 10;

    public override bool Decide(MJStateManager stateManager)
    {
        return Timer(stateManager);
    }

    public bool Timer(MJStateManager stateManager)
    {
        testTimer += Time.deltaTime;
        if (testTimer >= endTimer)
        {
            stateManager.curState = 0;
            testTimer = 0;
            return true;
        }
        else return false;
    }
}
