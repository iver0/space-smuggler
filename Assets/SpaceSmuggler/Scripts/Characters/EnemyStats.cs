using UnityEngine;

[CreateAssetMenu(menuName = "AI/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float MoveSpeed = 1f;
    public float AttackRange = 1f;
    public float AttackRate = 1f;
    public float AttackForce = 15f;
    public int AttackDamage = 50;
    public float LookSphereCastRadius = 1f;
}
