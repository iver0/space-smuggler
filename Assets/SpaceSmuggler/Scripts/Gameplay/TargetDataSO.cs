using System;
using UnityEngine;

namespace SpaceSmuggler
{
	public class TargetDataSO : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField] int _health;
		[NonSerialized] public int Health;

		public void OnAfterDeserialize()
		{
			Health = _health;
		}

		public void OnBeforeSerialize() { }
	}
}
