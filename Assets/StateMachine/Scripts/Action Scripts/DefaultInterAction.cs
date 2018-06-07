using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/DefaultInterAction")]
public class DefaultInterAction : ActionScript
{
    public override void Act(MJStateManager stateManager)
    {
        RandomState(stateManager);
    }

    void RandomState(MJStateManager stateManager)
    {
        //stateManager.RandomInteraction();
        stateManager.curState = 11;
    }
}
