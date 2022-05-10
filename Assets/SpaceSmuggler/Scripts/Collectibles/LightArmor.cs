using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Light armor item class.
	/// </summary>
	public class LightArmor : ItemSO
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
