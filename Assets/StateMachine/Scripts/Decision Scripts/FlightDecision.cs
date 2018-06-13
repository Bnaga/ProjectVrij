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
        if (!mainCamera) return false; //skip check if camera doesn't exist yet
        if (Vector3.Distance(mainCamera.transform.position, stateManager.transform.position) <= .25)
        {
            stateManager.inDanger = true;
            stateManager.onDestination = true;
            stateManager.isInteracting = false;
            return true;
        }
        else return false;
    }
}
