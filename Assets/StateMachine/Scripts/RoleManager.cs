using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoBehaviour {

    public enum Roles {leader,soldier, farmer, fisher, forager, villager}
    public Roles roles = new Roles();
    public int curRole = 0;
    

    private int currentRole = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (roles == Roles.leader)
        {
            currentRole = 1;
        }
        else if (roles == Roles.soldier)
        {
            currentRole = 2;
        }
        else if (roles == Roles.farmer)
        {
            currentRole = 3;
        }
        else if (roles == Roles.fisher)
        {
            currentRole = 4;
        }
        else if (roles == Roles.forager)
        {
            currentRole = 5;
        }
        else if (roles == Roles.villager)
        {
            currentRole = 0;
        }
        curRole = currentRole;
    }

    public int GetCurrentRole()
    {
        //Debug.Log(currentRole + this.gameObject.name);
        return currentRole;
    }


}
