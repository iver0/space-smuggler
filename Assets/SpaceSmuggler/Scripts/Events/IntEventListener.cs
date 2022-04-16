using UnityEngine;
using UnityEngine.Events;

public class IntEventListener : MonoBehaviour
{
	[SerializeField] IntEventChannelSO _channel = default;
	public UnityEvent<int> OnEventRaised;

	void OnEnable()
	{
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	void OnDisable()
	{
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	void Respond(int arg)
	{
		OnEventRaised?.Invoke(arg);
	}
}
