using System;
using UnityEngine;

namespace SpaceSmuggler
{
	[CreateAssetMenu(fileName = "VoidEvent_Channel", menuName = "Events/Void Event Channel")]
	public class VoidEventChannelSO : ScriptableObject
	{
		public event Action OnEventRaised;

		public void RaiseEvent()
		{
			OnEventRaised?.Invoke();
		}
	}
}
