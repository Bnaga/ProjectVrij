using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/InterAction")]
public class InterAction : ActionScript
{
    float timer = 0;
    public override void Act(MJStateManager stateManager)
    {
        ActTimer(stateManager);
    }

    void ActTimer(MJStateManager stateManager)
    {
        stateManager.waitIsOver = false;
        timer += Time.deltaTime;
        if(timer >= 10)
        {
            stateManager.waitIsOver = true;
        }
    }
}
