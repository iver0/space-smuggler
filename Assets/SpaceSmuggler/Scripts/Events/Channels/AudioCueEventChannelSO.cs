using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/AudioCue Event Channel")]
public class AudioCueEventChannelSO : ScriptableObject
{
	public event Action<AudioEventSO> OnAudioCueRequested;

	public void RaiseEvent(AudioEventSO audioEvent)
	{
		OnAudioCueRequested?.Invoke(audioEvent);
	}
}
