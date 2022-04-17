using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Holds audio manager scriptable object.
	/// </summary>
	public class AudioManager : MonoBehaviour
	{
		[SerializeField] AudioManagerSO _audioManager = default;

		void Awake()
		{
			var source = GetComponent<AudioSource>();
			_audioManager.Source = source;
		}
	}
}
