using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionScript : ScriptableObject
{
    public abstract void Act(MJStateManager stateManager);
}
