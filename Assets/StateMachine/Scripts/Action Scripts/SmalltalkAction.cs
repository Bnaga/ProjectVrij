using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/SmallTalkInterAction")]
public class SmalltalkAction : ActionScript
{
    public override void Act(MJStateManager stateManager)
    {
        throw new NotImplementedException();
    }

    void SmallTalk(MJStateManager stateManager)
    {
        
        if (!stateManager.soundCommunication.sourceNear.isPlaying && UnityEngine.Random.Range(0,100)<1)
            stateManager.AudioAction("smalltalk");
    }
}
