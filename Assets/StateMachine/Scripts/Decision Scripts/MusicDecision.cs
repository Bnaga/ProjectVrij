using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/MakeMusic")]
public class MusicDecision : Decision
{

    public override bool Decide(MJStateManager stateManager)
    {
        return CheckCurrentState(stateManager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.curState == 5)
        {
            stateManager.isMakingMusic = true;
            //stateManager.isInteracting = false;
            stateManager.onDestination = true;
            return true;
        }
        else return false;
    }
}
