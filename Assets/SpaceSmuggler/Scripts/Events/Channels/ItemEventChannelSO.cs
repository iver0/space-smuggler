using System;
using UnityEngine;

namespace SpaceSmuggler
{
	[CreateAssetMenu(fileName = "ItemEvent_Channel", menuName = "Events/Item Event Channel")]
	public class ItemEventChannelSO : ScriptableObject
	{
		public event Action<ItemSO> OnEventRaised;

		public void RaiseEvent(ItemSO item)
		{
			OnEventRaised?.Invoke(item);
		}
	}
}
