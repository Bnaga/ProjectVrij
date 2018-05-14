using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Color sceneGizmoColor = Color.gray;

    public void UpdateState(MJStateManager stateManager)
    {
        DoActions(stateManager);
    }

    private void DoActions(MJStateManager stateManager)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(stateManager);
        }
    }
}
