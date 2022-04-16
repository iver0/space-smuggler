using UnityEngine;

[CreateAssetMenu(fileName = "AttackAction", menuName = "AI/Actions/Attack")]
public class AttackAction : Actions
{
	public override void Act(StateController controller)
	{
		Attack(controller);
	}

	void Attack(StateController controller)
	{
		if (controller.CheckIfCountDownElapsed(controller.BotStats.AttackRate))
		{
			controller.Bot.Attack(controller.BotStats.AttackDamage);
		}
	}
}
