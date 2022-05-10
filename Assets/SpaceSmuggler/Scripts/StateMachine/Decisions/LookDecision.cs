using UnityEngine;

namespace SpaceSmuggler
{
	[CreateAssetMenu(fileName = "LookDecision", menuName = "AI/Decisions/Look")]
	public class LookDecision : Decisions
	{
		public override bool Decide(StateController controller)
		{
			bool playerInRange = Look(controller);
			return playerInRange;
		}

		bool Look(StateController controller)
		{
			RaycastHit2D hit = Physics2D.CircleCast(controller.transform.position, controller.BotStats.LookSphereCastRadius, controller.transform.forward, controller.BotStats.AttackRange);

			Debug.DrawRay(controller.transform.position, controller.transform.forward.normalized * controller.BotStats.AttackRange, Color.green);

			return hit && hit.collider.CompareTag("Player");
		}
	}
}
