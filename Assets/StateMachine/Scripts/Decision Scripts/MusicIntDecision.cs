using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/MusicInteraction")]
public class MusicIntDecision : Decision
{
    public override bool Decide(MJStateManager stateManager)
    {
        return CheckCurrentState(stateManager);
    }

    private bool CheckCurrentState(MJStateManager stateManager)
    {
        if (stateManager.isInteracting && stateManager.interactionTarget.GetComponent<MJStateManager>().isMakingMusic == true)
        {
            stateManager.onDestination = true;
            return true;
        }
        else return false;
    }
}
