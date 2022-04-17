using UnityEngine;

namespace SpaceSmuggler
{
	[CreateAssetMenu(fileName = "BotStats", menuName = "AI/Stats")]
	public class BotStats : ScriptableObject
	{
		public float MoveSpeed = 3f;
		public float AttackRange = 1f;
		public float AttackRate = 2f;
		public int AttackDamage = 10;
		public float LookSphereCastRadius = 1f;
	}
}
