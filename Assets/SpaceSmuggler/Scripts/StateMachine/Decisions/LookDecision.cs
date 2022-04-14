using UnityEngine;

[CreateAssetMenu(fileName = "LookDecision", menuName = "AI/Decisions/Look")]
public class LookDecision : Decision
{
	public override bool Decide(StateController controller)
	{
		bool targetVisible = Look(controller);
		return targetVisible;
	}

	bool Look(StateController controller)
	{
		RaycastHit2D hit = Physics2D.CircleCast(controller.transform.position, controller.EnemyStats.LookSphereCastRadius, controller.transform.forward, controller.EnemyStats.LookRange);

		Debug.DrawRay(controller.transform.position, controller.transform.forward.normalized * controller.EnemyStats.LookRange, Color.green);

		return hit && hit.collider.CompareTag("Player");
	}
}
