using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/GreetingAction")]
public class GreetingAction : ActionScript
{
    public override void Act(MJStateManager stateManager)
    {
        MakeGreeting(stateManager);
    }

    void MakeGreeting(MJStateManager stateManager)
    {
        if (!stateManager.soundCommunication.sourceNear.isPlaying)
            stateManager.AudioAction("greeting");
    }
}
