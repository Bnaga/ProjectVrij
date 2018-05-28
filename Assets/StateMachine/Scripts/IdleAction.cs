using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : ActionScript
{

    // Use this for initialization
    public override void Act(MJStateManager stateManager)
    {
        RandomState(stateManager);
    }

    void RandomState(MJStateManager stateManager)
    {
        if(UnityEngine.Random.Range(0, 100) <= 10)
        {
            stateManager.RandomState();
        }
    }
}
