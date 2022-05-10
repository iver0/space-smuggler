using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Blueprint for item classes.
	/// </summary>
	public abstract class ItemSO : ScriptableObject
	{
		public int Increment;
		public int NewMax;
		public int Duration;
		public AudioEventSO AudioEvent;
		[HideInInspector] public bool IsCollected;
		[HideInInspector] public GameObject gameObject;

		/// <summary>
		/// Performs collect logic when triggered.
		/// </summary>
		public abstract void Collect(GameObject go);

		/// <summary>
		/// Plays a pickup sound and destroys the object if the item was collected.
		/// </summary>
		public void OnPickup()
		{
			AudioEvent.Play();
			Destroy(gameObject);
		}
	}
}
