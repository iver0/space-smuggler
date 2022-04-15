using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackAction", menuName = "AI/Actions/Attack")]
public class AttackAction : Action
{
	public override void Act(StateController controller)
	{
		Attack(controller);
	}

	void Attack(StateController controller)
	{
		if (controller.CheckIfCountDownElapsed(controller.EnemyStats.AttackRate))
		{
			controller.Enemy.Attack(controller.EnemyStats.AttackDamage);
		}
	}
}
