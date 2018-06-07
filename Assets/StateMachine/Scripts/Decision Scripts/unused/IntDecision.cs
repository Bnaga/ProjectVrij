using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IntDecision")]
public class IntDecision : Decision
{
    float friendDistance = 0.1f;
    float neighborDistance = 0.1f;
    public State interState;

    public override bool Decide(MJStateManager stateManager)
    {
        return CheckNeighbor(stateManager);
    }

    private bool CheckNeighbor(MJStateManager stateManager)
    {
        stateManager.otherIsLeader = false;
        GameObject[] mojili = GameObject.FindGameObjectsWithTag("Mojili");
        for (int i = 0; i < mojili.Length; i++)
        {
            float tempfriendDistance = Vector3.Distance(stateManager.transform.position, mojili[i].transform.position);
            //Debug.Log(tempfriendDistance);
            if ((tempfriendDistance <= friendDistance) && (mojili[i].name != stateManager.gameObject.name) && stateManager.waitIsOver && !mojili[i].GetComponent<MJStateManager>().isInteracting)
            {
                //Debug.Log("test");
                GameObject target = GetTarget(stateManager, mojili);
                MJStateManager targetStateMan = GetTarget(stateManager, mojili).GetComponent<MJStateManager>();

                stateManager.interactionTarget = target;
                targetStateMan.interactionTarget = stateManager.gameObject;
                targetStateMan.currentState = interState;
                Debug.Log(mojili[i].GetComponent<RoleManager>().GetCurrentRole() + mojili[i].name);
                if (mojili[i].GetComponent<RoleManager>().GetCurrentRole() == 1)
                {
                    stateManager.otherIsLeader = true;
                }
                targetStateMan.isInteracting = true;
                targetStateMan.waitIsOver = true;
                stateManager.isInteracting = true;
                stateManager.onDestination = true;
                return true;
            }
            else return false;
        }
        return false;
    }

    public GameObject GetTarget(MJStateManager stateManager, GameObject[] array)
    {
        neighborDistance = 0.2f;
        GameObject[] mojili = array;
        GameObject currentTarget = null;
        for (int i = 0; i < mojili.Length; i++)
        {

            float tempmojDistance = Vector3.Distance(stateManager.transform.position, mojili[i].transform.position);
            if (tempmojDistance <= friendDistance && (mojili[i].name != stateManager.gameObject.name) && !mojili[i].GetComponent<MJStateManager>().isInteracting)
            {
                neighborDistance = tempmojDistance;
                currentTarget = mojili[i];
                //Debug.Log(houses[i].name);
            }
        }
        return currentTarget;
    }
}
