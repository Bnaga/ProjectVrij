using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MusicAction")]
public class MusicAction : ActionScript
{
    public AudioClip testSound;

    public override void Act(MJStateManager stateManager)
    {
        PlayMusic(stateManager);
    }

    void PlayMusic(MJStateManager stateManager)
    {
        stateManager.isMakingMusic = true;
        stateManager.gameObject.GetComponent<soundCommunication>().PlaySound(testSound);
    }
}
