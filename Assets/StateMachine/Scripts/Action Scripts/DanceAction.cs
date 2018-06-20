﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DanceAction : ActionScript
{

    public override void Act(MJStateManager stateManager)
    {
        GoDance(stateManager);
        stateManager.StartInteractiontimer();
    }

    void GoDance(MJStateManager stateManager)
    {
        stateManager.animator.SetBool("isDancing", true);
    }
}
