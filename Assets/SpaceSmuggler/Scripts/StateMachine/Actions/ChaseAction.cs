using UnityEngine;

namespace SpaceSmuggler
{
    [CreateAssetMenu(fileName = "ChaseAction", menuName = "AI/Actions/Chase")]
    public class ChaseAction : Actions
    {
        public override void Act(StateController controller)
        {
            Chase(controller);
        }

        void Chase(StateController controller)
        {
            var agentDrift = 0.0001f;
            var driftPos = controller.Target.position + (Vector3)(agentDrift * Random.insideUnitCircle);
            controller.NavMeshAgent.SetDestination(driftPos);
            controller.NavMeshAgent.isStopped = false;
            RotateTowardsTarget(controller);
        }

        void RotateTowardsTarget(StateController controller)
        {
            var offset = 90f;
            Vector2 direction = controller.Target.position - controller.transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            controller.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        }
    }
}
