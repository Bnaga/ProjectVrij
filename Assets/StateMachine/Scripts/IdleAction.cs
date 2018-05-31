using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Idle")]
public class IdleAction : ActionScript
{

    // Use this for initialization
    public override void Act(MJStateManager stateManager)
    {
        RandomState(stateManager);
    }

    void RandomState(MJStateManager stateManager)
    {
        RoleManager role = stateManager.gameObject.GetComponent<RoleManager>();
        if (UnityEngine.Random.Range(0, 1000) <= 10 && role.GetCurrentRole() == 0)
        {
            stateManager.RandomState();
        }
    }
}
