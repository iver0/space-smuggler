using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Gameplay/Weapon Stats")]
public class WeaponStatsSO : ScriptableObject
{
	public AudioEventSO FiringSound;
	public int Damage;
	public bool IsAutomatic;
	public float FireRate;
	public float Spread;
}
