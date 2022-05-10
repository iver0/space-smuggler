using System;
using UnityEngine;

namespace SpaceSmuggler
{
	[CreateAssetMenu(fileName = "IntEvent_Channel", menuName = "Events/Int Event Channel")]
	public class IntEventChannelSO : ScriptableObject
	{
		public event Action<int> OnEventRaised;

		public void RaiseEvent(int arg)
		{
			OnEventRaised?.Invoke(arg);
		}
	}
}
