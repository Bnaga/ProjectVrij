using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDecision : Decision
{
    float friendDistance = 0.01f;

    public override bool Decide(MJStateManager stateManager)
    {
        throw new NotImplementedException();
    }

    private bool CheckNeighbor(MJStateManager stateManager)
    {
        GameObject[] mojili = GameObject.FindGameObjectsWithTag("Mojili");

        for (int i = 0; i < mojili.Length; i++)
        {

            float tempfriendDistance = Vector3.Distance(stateManager.transform.position, mojili[i].transform.position);
            if (tempfriendDistance <= friendDistance && tempfriendDistance != 0)
            {
                return true;
            }
            
        }
        return false;
    }
}
