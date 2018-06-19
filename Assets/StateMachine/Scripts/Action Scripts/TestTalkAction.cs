using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/TestTalk")]
public class TestTalkAction : ActionScript
{
    private fishDictionary.word[] words;

    public override void Act(MJStateManager stateManager)
    {
        TestTalk(stateManager);
    }
    
    void TestTalk(MJStateManager stateManager)
    {
        if (!stateManager.soundCommunication.sourceNear.isPlaying && UnityEngine.Random.Range(0, 100) < 10)
        {
            stateManager.AudioAction("smalltalk");
        }
        stateManager.StartInteractiontimer();
    }
}
 