﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/BackToIdle")]
public class BackToIdleDecision : Decision
{

    public override bool Decide(MJStateManager stateManager)
    {
        return Timer(stateManager);
    }

    public bool Timer(MJStateManager stateManager)
    {
        if (stateManager.coolDown)
        {
            stateManager.curState = 0;
            //stateManager.coolDown = true;
            //stateManager.StartCoroutine("CoolDownTimer");
            return true;
        }
        else return false;
    }
}
