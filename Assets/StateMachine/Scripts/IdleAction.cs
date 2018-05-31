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
        int rand = UnityEngine.Random.Range(0, 1000);
        if ( rand <= 10 && role.GetCurrentRole() == 0)
        {
            stateManager.RandomState();
        }

        if (rand <= 10 && (role.GetCurrentRole() == 1 || role.GetCurrentRole() == 2))
        {
            stateManager.RandomSoldierState();
        }

        if (rand <= 10 && (role.GetCurrentRole() == 3 || role.GetCurrentRole() == 4))
        {
            stateManager.RandomFarmerState();
        }

        if (role.GetCurrentRole() == 5  && stateManager.hasFood)
        {
            stateManager.curState = 9;
        }

        if (role.GetCurrentRole() == 5 && !stateManager.hasFood)
        {
            stateManager.curState = 10;
        }
    }
}
