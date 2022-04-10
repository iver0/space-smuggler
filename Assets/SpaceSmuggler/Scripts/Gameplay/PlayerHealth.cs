using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action HealthChanged;
    public static event Action<GameObject> ItemCollected;
    [SerializeField] PlayerData playerData;
    int tempMaxHealth;

    void OnEnable()
    {
        Medkit.MedkitCollected += OnItemCollected;
        Morphine.MorphineCollected += OnItemCollected;
    }

    void OnDisable()
    {
        Medkit.MedkitCollected -= OnItemCollected;
        Morphine.MorphineCollected -= OnItemCollected;
    }

    void OnItemCollected(GameObject item, int value)
    {
        if (playerData.Health != playerData.MaxHealth)
        {
            if (playerData.Health + value < playerData.MaxHealth)
            {
                playerData.Health += value;
            }
            else
            {
                playerData.Health = playerData.MaxHealth;
            }
            ItemCollected?.Invoke(item);
            HealthChanged?.Invoke();
        }
    }

    void OnItemCollected(GameObject item, int value, int maxValue)
    {
        playerData.MaxHealth = maxValue;
        OnItemCollected(item, value);
    }

    void OnItemCollected(GameObject item, int value, int maxValue, bool isTemp, int duration)
    {
        if (isTemp)
        {
            tempMaxHealth = playerData.MaxHealth;
            StartCoroutine(FadeEffect(duration));
        }
        OnItemCollected(item, value, maxValue);
    }

    IEnumerator FadeEffect(int duration)
    {
        yield return new WaitForSeconds(duration);
        OnItemCollected(gameObject, 0, tempMaxHealth);
    }
}
