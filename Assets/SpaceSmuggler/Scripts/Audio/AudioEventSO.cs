using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Easily create customizable audio events.
	/// </summary>
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

		/// <summary>
		/// Sends an audio cue request to the audio manager.
		/// </summary>
		public void Play()
		{
			if (Clips.Length == 0) return;
			_SFXEventChannel.RaiseEvent(this);
		}
	}
}
