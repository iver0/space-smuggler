using System;
using UnityEngine;

public class LightArmor : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int, int> LightArmorCollected;

    [SerializeField]
    AudioEvent _audioEvent;

    void OnEnable()
    {
        PlayerArmor.ItemCollected += OnItemCollected;
    }

    void OnDisable()
    {
        PlayerArmor.ItemCollected -= OnItemCollected;
    }

    public void Collect()
    {
        LightArmorCollected?.Invoke(gameObject, 25, 75);
    }

    public void OnItemCollected(GameObject item)
    {
        if (GameObject.ReferenceEquals(item, gameObject))
        {
            // Creating a new empty GameObject so that pickup sound can play
            gameObject.SetActive(false);
            GameObject go = new GameObject("MedkitCollectedSFX");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            _audioEvent.Play(audioSource);
            Destroy(go, 1f);
            Destroy(gameObject);
        }
    }
}
