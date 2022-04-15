using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] AudioManagerSO _audioManager = default;

	void Awake()
	{
		var source = GetComponent<AudioSource>();
		_audioManager.Source = source;
	}
}
