using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Holds item scriptable object.
	/// </summary>
	public class Item : MonoBehaviour
	{
		[SerializeField] ItemSO _item = default;

		/// <summary>
		/// Triggers ItemSO.Collect() method of this instance.
		/// </summary>
		public void Collect()
		{
			_item.Collect(gameObject);
		}
	}
}
