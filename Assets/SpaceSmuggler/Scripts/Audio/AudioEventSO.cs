using UnityEngine;

[CreateAssetMenu(menuName = "Events/Audio Event")]
public class AudioEventSO : ScriptableObject
{
	public AudioClip[] Clips;
	public RangedFloat Volume;
	[MinMaxRange(0, 2)]
	public RangedFloat Pitch;
	[Header("Broadcasting on")]
	[SerializeField] AudioCueEventChannelSO _SFXEventChannel = default;
	[HideInInspector] public AudioSource Source;

	public void Play()
	{
		if (Clips.Length == 0) return;
		_SFXEventChannel.RaiseEvent(this);
	}
}
