using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Armor item class.
	/// </summary>
	public class Armor : ItemSO
	{
		[Header("Broadcasting on")]
		[SerializeField] ItemEventChannelSO _armorItemEvent = default;

		/// <summary>
		/// Increments player's armor.
		/// </summary>
		public override void Collect(GameObject go)
		{
			gameObject = go;
			_armorItemEvent.RaiseEvent(this);
			if (IsCollected) OnPickup();
		}
	}
}
