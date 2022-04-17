using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Scriptable object for easy weapon configuration.
	/// </summary>
	[CreateAssetMenu(fileName = "Weapon", menuName = "Gameplay/Weapon")]
	public class WeaponSO : ScriptableObject
	{
		public AudioEventSO FiringSound;
		[Range(0, 100)]
		public int Damage;
		public bool IsAutomatic;
		[Tooltip("Weapon firing rate.")]
		public float FireRate;
		[Tooltip("Weapon spread.")]
		[Range(0, 1)]
		public float Spread;
	}
}
