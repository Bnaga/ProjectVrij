using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MusicAction")]
public class MusicAction : ActionScript
{

    public override void Act(MJStateManager stateManager)
    {
        PlayMusic(stateManager);
        stateManager.StartInteractiontimer();
    }

    void PlayMusic(MJStateManager stateManager)
    {
        stateManager.isMakingMusic = true;
        if (!stateManager.soundCommunication.sourceNear.isPlaying)
            stateManager.AudioAction("music");
    }
}
