using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Idle")]
public class IdleAction : ActionScript
{
    float timer = 0;
    // Use this for initialization
    public override void Act(MJStateManager stateManager)
    {
        RandomState(stateManager);
        ActTimer(stateManager);
    }

    void RandomState(MJStateManager stateManager)
    {
        //stateManager.otherIsLeader = false;
        RoleManager role = stateManager.gameObject.GetComponent<RoleManager>();
        int rand = UnityEngine.Random.Range(0, 100);
        if ( rand <= 10 && role.GetCurrentRole() == 0)
        {
            stateManager.RandomState();
        }

        if (rand <= 10 && role.GetCurrentRole() == 2)
        {
            stateManager.RandomSoldierState();
        }

        if (rand <= 10 && (role.GetCurrentRole() == 3 || role.GetCurrentRole() == 4))
        {
            stateManager.RandomFarmerState();
        }

        if (role.GetCurrentRole() == 5  && !stateManager.hasFood)
        {
            stateManager.curState = 16; //forage action
        }

        if (role.GetCurrentRole() == 5 && stateManager.hasFood)
        {
            stateManager.curState = 17;
        }
    }

    void ActTimer(MJStateManager stateManager)
    {
        stateManager.waitIsOver = false;
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            stateManager.waitIsOver = true;
            timer = 0;
        }
    }
}

