using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Hide")]
public class HideAction : ActionScript
{
    float testTimer = 0;
    float endTimer = 10;

    public override void Act(MJStateManager stateManager)
    {
        CheckForSafety(stateManager);
    }

    public void CheckForSafety(MJStateManager stateManager)
    {
        testTimer += Time.deltaTime;
        if (testTimer >= endTimer && stateManager.inDanger)
        {
            if(!SafetyTest(stateManager))
            {
                stateManager.inDanger = false;
                stateManager.hide = false;
            }
            testTimer = 0;
        }
    }

    public bool SafetyTest(MJStateManager stateManager)
    {
        Camera mainCamera = Camera.main;
        if (Vector3.Distance(mainCamera.transform.position, stateManager.transform.position) <= 1)
        {
            Debug.Log("Panic!!");
            stateManager.inDanger = true;
            return true;
        }
        else return false;
    }
}
