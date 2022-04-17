using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Heavy armor item class.
	/// </summary>
	public class HeavyArmor : ItemSO
	{
		[Header("Broadcasting on")]
		[SerializeField] ItemEventChannelSO _armorItemEvent = default;

		/// <summary>
		/// Increments player's armor and sets new max armor.
		/// </summary>
		public override void Collect(GameObject go)
		{
			gameObject = go;
			_armorItemEvent.RaiseEvent(this);
			if (IsCollected) OnPickup();
		}
	}
}
