using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Medkit item class.
	/// </summary>
	public class Medkit : ItemSO
	{
		[Header("Broadcasting on")]
		[SerializeField] ItemEventChannelSO _healthItemEvent = default;

		/// <summary>
		/// Increments player's health.
		/// </summary>
		public override void Collect(GameObject go)
		{
			gameObject = go;
			_healthItemEvent.RaiseEvent(this);
			if (IsCollected) OnPickup();
		}
	}
}
