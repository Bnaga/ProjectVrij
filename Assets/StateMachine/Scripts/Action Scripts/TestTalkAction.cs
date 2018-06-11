using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/TestTalk")]
public class TestTalkAction : ActionScript
{
    public AudioClip testSound;

    public override void Act(MJStateManager stateManager)
    {
        TestTalk(stateManager);
    }
    
    void TestTalk(MJStateManager stateManager)
    {
        //stateManager.gameObject.GetComponent<soundCommunication>().PlaySound(testSound);
        stateManager.StartInteractiontimer();
    }
}
