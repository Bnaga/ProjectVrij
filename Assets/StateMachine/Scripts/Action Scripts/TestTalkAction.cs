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
        fishDictionary.word[] words = stateManager.dictionary.dictionary;
        fishDictionary.word sound = words[UnityEngine.Random.Range(0,words.Length)];
		stateManager.soundCommunication.playWord(sound, stateManager.dictionary);
        stateManager.StartInteractiontimer();
        Transform t = stateManager.transform;
        Debug.DrawLine(t.position,t.position + t.up,Color.green);
    }
}
