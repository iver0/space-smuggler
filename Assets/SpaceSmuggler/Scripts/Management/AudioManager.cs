using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audioSource;

    void Awake()
    {
        // Initialize singleton AudioManager
        if (Instance != null && Instance != this)
        {
            Debug.Log("Destroying duplicate AudioManager Instance");
            Destroy(this);
        }
        else
        {
            Debug.Log("Setting AudioManager Instance");
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip, float volumeScale = 1f)
    {
        audioSource.PlayOneShot(clip, volumeScale);
    }
}
