using UnityEngine;

namespace SpaceSmuggler
{
	public class Collector : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent<Item>(out var item))
				item.Collect();
		}
	}
}
