using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/MusicInterAction")]
public class MusicInterAction : ActionScript
{
    public override void Act(MJStateManager stateManager)
    {
        RandomMusicState(stateManager);
    }

    void RandomMusicState(MJStateManager stateManager)
    {
        stateManager.MusicInteraction();
    }
}
