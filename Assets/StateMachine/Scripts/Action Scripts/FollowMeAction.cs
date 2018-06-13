using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/FollowMeAction")]
public class FollowMeAction : ActionScript
{
    public override void Act(MJStateManager stateManager)
    {
        FollowSound(stateManager);
    }

    void FollowSound(MJStateManager stateManager)
    {
        if (!stateManager.soundCommunication.sourceNear.isPlaying)
            stateManager.AudioAction("followme");
        stateManager.StartInteractiontimer();
    }

}
