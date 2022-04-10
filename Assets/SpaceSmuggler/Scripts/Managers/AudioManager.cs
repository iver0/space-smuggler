using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audioSource;

    void Awake()
    {
        // Ensure that there is only one instance of the audio manager
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip, float volumeScale = 1f)
    {
        audioSource.PlayOneShot(clip, volumeScale);
    }
}
