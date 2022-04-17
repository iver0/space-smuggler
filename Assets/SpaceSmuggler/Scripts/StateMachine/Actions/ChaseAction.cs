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
			controller.NavMeshAgent.SetDestination(controller.PlayerTransform.position);
			controller.NavMeshAgent.isStopped = false;
		}
	}
}
