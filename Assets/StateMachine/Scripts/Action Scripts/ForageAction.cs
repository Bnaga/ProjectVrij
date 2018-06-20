using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Forage")]
public class ForageAction : ActionScript
{
    GameObject[] food;
    float foodDistance = 100;
    private Vector3 target;
    //bool onDestination = true;

    public override void Act(MJStateManager stateManager)
    {
        GoToFood(stateManager);
    }

    private void GoToFood(MJStateManager stateManager)
    {
        //onDestination = stateManager.onDestination;
        if (Vector3.Distance(stateManager.transform.position, target) > .2f)
        {
            target = FindFood(stateManager);
            stateManager.navMeshAgent.SetDestination(target);
            //Debug.Log(stateManager.navMeshAgent.destination);
            //stateManager.onDestination = false;
        }

        if(stateManager.food == null)
        {
            target = FindFood(stateManager);
            stateManager.navMeshAgent.SetDestination(target);
        }
        
        if (Vector3.Distance(stateManager.transform.position, target) <= .125f)
        {
            //stateManager.onDestination = true;
            FoodPickup(stateManager);
            stateManager.curState = 17;
        }
    }

    Vector3 FindFood(MJStateManager stateManager)
    {
        foodDistance = 100;
        food = GameObject.FindGameObjectsWithTag("Food");
        Vector3 currentTarget = Vector3.zero;
        for (int i = 0; i < food.Length; i++)
        {

            float tempfoodDistance = Vector3.Distance(stateManager.transform.position, food[i].transform.position);
            if (tempfoodDistance <= foodDistance && tempfoodDistance != 0)
            {
                foodDistance = tempfoodDistance;
                //currentTarget = new Vector3(food[i].transform.position.x , 0, food[i].transform.position.z );
                currentTarget = food[i].transform.position;
                stateManager.food = food[i];
            }
        }
        return currentTarget;
    }

    void FoodPickup(MJStateManager stateManager)
    {
        if(stateManager.food !=null)
        {
            stateManager.food.transform.rotation = stateManager.transform.rotation;
            Vector3 targetPos = stateManager.transform.position + stateManager.transform.forward * stateManager.offset.z + stateManager.transform.right * stateManager.offset.x + stateManager.transform.up * stateManager.offset.y;
            stateManager.food.transform.position = targetPos;
            stateManager.hasFood = true;
            stateManager.food.GetComponent<Rigidbody>().isKinematic = true;
            stateManager.food.GetComponent<FoodDecay>().pickedUp = true;
            stateManager.animator.SetBool("holding", true);
        }

    }

}
