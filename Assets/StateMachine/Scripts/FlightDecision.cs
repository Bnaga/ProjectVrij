using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Flight")]
public class FlightDecision : Decision
{
    public override bool Decide(MJStateManager stateManager)
    {
        return TrackPlayer(stateManager);
    }

    public bool TrackPlayer(MJStateManager stateManager)
    {
        Camera mainCamera = Camera.main;
        if (Vector3.Distance(mainCamera.transform.position, stateManager.transform.position) <= 20)
        {
            stateManager.inDanger = true;
            return true;
        }
        else return false;
    }
}
