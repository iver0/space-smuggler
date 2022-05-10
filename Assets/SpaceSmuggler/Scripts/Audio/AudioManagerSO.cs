using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceSmuggler
{
    /// <summary>
    /// Project audio management.
    /// </summary>
    [CreateAssetMenu(fileName = "AudioManager", menuName = "Gameplay/Audio Manager")]
    public class AudioManagerSO : ScriptableObject
    {
        [Header("Listening on")]
        [SerializeField] AudioCueEventChannelSO _SFXEventChannel = default;
        [HideInInspector] public AudioSource Source;

        void OnEnable()
        {
            _SFXEventChannel.OnAudioCueRequested += Play;
        }

        void OnDisable()
        {
            _SFXEventChannel.OnAudioCueRequested -= Play;
        }

        /// <summary>
        /// Plays audio with the specified configuration.
        /// </summary>
        public void Play(AudioEventSO audioEvent)
        {
            AudioSource source;
            if (audioEvent.Source != null)
                source = audioEvent.Source;
            else
                source = Source;
            source.clip = audioEvent.Clips[Random.Range(0, audioEvent.Clips.Length)];
            source.volume = Random.Range(audioEvent.Volume.minValue, audioEvent.Volume.maxValue);
            source.pitch = Random.Range(audioEvent.Pitch.minValue, audioEvent.Pitch.maxValue);
            source.Play();
        }
    }
}
