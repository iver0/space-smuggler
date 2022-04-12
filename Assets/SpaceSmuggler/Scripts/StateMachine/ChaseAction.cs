using UnityEngine;

[CreateAssetMenu(fileName = "ChaseAction", menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    void Chase(StateController controller)
    {
        controller.NavMeshAgent.destination = controller.PlayerTransform.position;
        controller.NavMeshAgent.isStopped = false;
    }
}
