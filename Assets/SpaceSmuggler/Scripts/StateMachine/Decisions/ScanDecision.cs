using UnityEngine;

namespace SpaceSmuggler
{
	[CreateAssetMenu(menuName = "AI/Decisions/Scan")]
	public class ScanDecision : Decisions
	{
		public override bool Decide(StateController controller)
		{
			bool noEnemyInSight = Scan(controller);
			return noEnemyInSight;
		}

		bool Scan(StateController controller)
		{
			controller.NavMeshAgent.isStopped = true;
			controller.transform.Rotate(0, controller.BotStats.SearchingTurnSpeed * Time.deltaTime, 0);
			return controller.CheckIfCountDownElapsed(controller.BotStats.SearchDuration);
		}
	}
}
