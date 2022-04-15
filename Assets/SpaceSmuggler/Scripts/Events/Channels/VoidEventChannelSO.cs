using UnityEngine;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
	public event System.Action OnEventRaised;

	public void RaiseEvent()
	{
		OnEventRaised?.Invoke();
	}
}
