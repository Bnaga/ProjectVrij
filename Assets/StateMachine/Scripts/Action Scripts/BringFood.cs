using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/BringFood")]
public class BringFood : ActionScript
{

    private GameObject[] houses;
    private float houseDistance = 100;
    private Vector3 target;
    bool onDestination = true;
    Vector3 mojiDestination;

    public override void Act(MJStateManager stateManager)
    {
        BringToHouse(stateManager);
        FoodPickup(stateManager);
    }

    public void BringToHouse(MJStateManager stateManager)
    {
        onDestination = stateManager.onDestination;
        if (onDestination)
        {
            target = GetTarget(stateManager);
            stateManager.navMeshAgent.SetDestination(target);
            stateManager.onDestination = false;
        }

        if (Vector3.Distance(stateManager.transform.position, target) <= .1f)
        {
            stateManager.onDestination = true;
            Destroy(stateManager.food.gameObject);
            stateManager.hasFood = false;
        }
    }

    private Vector3 GetTarget(MJStateManager stateManager)
    {
        houseDistance = 100;
        houses = GameObject.FindGameObjectsWithTag("House");
        Vector3 currentTarget = Vector3.zero;
        //Debug.Log(houses.Length);
        for (int i = 0; i < houses.Length; i++)
        {

            float temphouseDistance = Vector3.Distance(stateManager.transform.position, houses[i].transform.position);
            if (temphouseDistance <= houseDistance)
            {
                houseDistance = temphouseDistance;
                //Debug.Log(houseDistance);
                currentTarget = new Vector3(houses[i].transform.position.x, 0, houses[i].transform.position.z);
            }
        }
        return currentTarget;
    }

    void FoodPickup(MJStateManager stateManager)
    {
        if (stateManager.food != null)
        {
            stateManager.food.transform.rotation = stateManager.transform.rotation;
            Vector3 targetPos = stateManager.transform.position + stateManager.transform.forward * stateManager.offset.z + stateManager.transform.right * stateManager.offset.x + stateManager.transform.up * stateManager.offset.y;
            stateManager.food.transform.position = targetPos;
            stateManager.food.GetComponent<Rigidbody>().isKinematic = true;
        }

    }
}