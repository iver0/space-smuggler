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
			var driftPos = controller.PlayerTransform.position + (Vector3)(agentDrift * Random.insideUnitCircle);
			controller.NavMeshAgent.SetDestination(driftPos);
			controller.NavMeshAgent.isStopped = false;
		}
	}
}
