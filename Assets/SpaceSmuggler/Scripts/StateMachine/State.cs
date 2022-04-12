using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject
{
    public Action[] Actions;

    public void UpdateState(StateController controller)
    {
        DoActions(controller);
    }

    void DoActions(StateController controller)
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].Act(controller);
        }
    }
}
