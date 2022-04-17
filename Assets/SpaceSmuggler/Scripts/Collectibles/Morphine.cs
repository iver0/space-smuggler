using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Morphine item class.
	/// </summary>
	[CreateAssetMenu(menuName = "Gameplay/Items/Morphine")]
	public class Morphine : ItemSO
	{
		[Header("Broadcasting on")]
		[SerializeField] ItemEventChannelSO _healthItemEvent = default;

		/// <summary>
		/// Increments player's health and sets new max health for a limited amount of time.
		/// </summary>
		public override void Collect(GameObject go)
		{
			gameObject = go;
			_healthItemEvent.RaiseEvent(this);
			if (IsCollected) OnPickup();
		}
	}
}
