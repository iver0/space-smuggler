using UnityEngine;

namespace SpaceSmuggler
{
	[CreateAssetMenu(fileName = "BotStats", menuName = "AI/Stats")]
	public class BotStats : ScriptableObject
	{
		public float MoveSpeed;
		public float AttackRange;
		public float AttackRate;
		public int AttackDamage;
		public float LookSphereCastRadius;
		public float SearchingTurnSpeed;
		public float SearchDuration;
	}
}
