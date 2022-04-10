using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnHealthChanged;
    public static event Action<GameObject> OnCollectibleCollected;
    [SerializeField] PlayerData playerData;
    int tempMaxHealth;

    void OnEnable()
    {
        Medkit.OnMedkitCollected += ChangeHealth;
        Morphine.OnMorphineCollected += ChangeHealth;
    }

    void OnDisable()
    {
        Medkit.OnMedkitCollected -= ChangeHealth;
        Morphine.OnMorphineCollected -= ChangeHealth;
    }

    void ChangeHealth(GameObject collectible, int value)
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
            OnCollectibleCollected?.Invoke(collectible);
            OnHealthChanged?.Invoke();
        }
    }

    void ChangeHealth(GameObject collectible, int value, int maxValue)
    {
        playerData.MaxHealth = maxValue;
        ChangeHealth(collectible, value);
    }

    void ChangeHealth(GameObject collectible, int value, int maxValue, bool isTemp, int duration)
    {
        if (isTemp)
        {
            tempMaxHealth = playerData.MaxHealth;
            StartCoroutine(EffectDuration(duration));
        }
        ChangeHealth(collectible, value, maxValue);
    }

    IEnumerator EffectDuration(int duration)
    {
        yield return new WaitForSeconds(duration);
        ChangeHealth(gameObject, 0, tempMaxHealth);
    }
}
