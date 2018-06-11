using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AlertAction")]
public class AlertAction : ActionScript
{
    public override void Act(MJStateManager stateManager)
    {
        Alerting(stateManager);
    }

    void Alerting(MJStateManager stateManager)
    {
        if (!stateManager.soundCommunication.sourceNear.isPlaying)
            stateManager.AudioAction("alert");
    }
}
