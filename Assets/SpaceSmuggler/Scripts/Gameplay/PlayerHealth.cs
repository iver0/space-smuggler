using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnHealthChanged;
    [SerializeField] PlayerData playerData;

    void OnEnable()
    {
        Medkit.OnMedkitCollected += ChangeHealth;
    }

    void OnDisable()
    {
        Medkit.OnMedkitCollected -= ChangeHealth;
    }

    void ChangeHealth(int value, GameObject collectible)
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
            Destroy(collectible);
            OnHealthChanged?.Invoke();
        }
    }
}
