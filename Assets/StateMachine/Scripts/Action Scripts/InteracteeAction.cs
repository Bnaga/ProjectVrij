using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/InterActee")]
public class InteracteeAction : ActionScript 
{
	public override void Act(MJStateManager stateManager)
	{
		ActTimer(stateManager);
	}

	void ActTimer(MJStateManager stateManager)
	{
		stateManager.StartInteractiontimer();
	}
}
