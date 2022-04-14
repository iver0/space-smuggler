using UnityEngine;

[CreateAssetMenu(menuName = "AI/EnemyStats")]
public class EnemyStats : ScriptableObject
{
	public float MoveSpeed = 3f;
	public float AttackRange = 1f;
	public float AttackRate = 2f;
	public int AttackDamage = 10;
	public float LookSphereCastRadius = 1f;
}
