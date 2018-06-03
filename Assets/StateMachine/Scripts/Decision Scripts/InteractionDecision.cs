using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/InteractionDecision")]
public class InteractionDecision : Decision
{
    float friendDistance = 0.5f;

    public override bool Decide(MJStateManager stateManager)
    {
        return CheckNeighbor(stateManager);
    }

    private bool CheckNeighbor(MJStateManager stateManager)
    {
        GameObject[] mojili = GameObject.FindGameObjectsWithTag("Mojili");
        for (int i = 0; i < mojili.Length; i++)
        {
            float tempfriendDistance = Vector3.Distance(stateManager.transform.position, mojili[i].transform.position);
            Debug.Log(tempfriendDistance);
            if ((tempfriendDistance <= friendDistance) && tempfriendDistance != 0)
            {
                Debug.Log("test");
                stateManager.interactionTarget = mojili[i];
                mojili[i].GetComponent<MJStateManager>().isInteracting = true;
                stateManager.isInteracting = true;
                stateManager.onDestination = true;
                return true;
            }
        }
        return false;
    }
}
