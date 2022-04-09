using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnHealthChanged;
    [SerializeField] PlayerData playerData;

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

    void ChangeHealth(int value)
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
            OnHealthChanged?.Invoke();
        }
    }

    void ChangeHealth(int value, int maxValue)
    {
        playerData.MaxHealth = maxValue;
        ChangeHealth(value);
    }
}
