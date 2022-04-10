using System;
using UnityEngine;

public class HeavyArmor : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int, int> HeavyArmorCollected;
    [SerializeField] AudioEvent audioEvent;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        HeavyArmorCollected?.Invoke(gameObject, 25, 125);
    }

    public void OnItemCollected(GameObject item)
    {
        if (GameObject.ReferenceEquals(item, gameObject))
        {
            audioEvent.Play(audioSource);
            Destroy(gameObject);
        }
    }
}
