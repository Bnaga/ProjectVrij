using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/DanceAction")]
public class DanceAction : ActionScript
{

    public override void Act(MJStateManager stateManager)
    {
        GoDance(stateManager);
        stateManager.StartInteractiontimer();
    }

    void GoDance(MJStateManager stateManager)
    {
        stateManager.hasFood = false;
        Destroy(stateManager.food);
        stateManager.animator.SetBool("isDancing", true);   

    }
}
