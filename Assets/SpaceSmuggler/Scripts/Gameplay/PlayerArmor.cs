using System;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    public static event Action ArmorChanged;
    public static event Action<GameObject> ItemCollected;
    [SerializeField] PlayerData playerData;

    void OnEnable()
    {
        Armor.ArmorCollected += OnItemCollected;
        LightArmor.LightArmorCollected += OnItemCollected;
        HeavyArmor.HeavyArmorCollected += OnItemCollected;
    }

    void OnDisable()
    {
        Armor.ArmorCollected -= OnItemCollected;
        LightArmor.LightArmorCollected -= OnItemCollected;
        HeavyArmor.HeavyArmorCollected -= OnItemCollected;
    }

    void OnItemCollected(GameObject item, int value)
    {
        if (playerData.Armor != playerData.MaxArmor)
        {
            if (playerData.Armor + value < playerData.MaxArmor)
            {
                playerData.Armor += value;
            }
            else
            {
                playerData.Armor = playerData.MaxArmor;
            }
            ItemCollected?.Invoke(item);
            ArmorChanged?.Invoke();
        }
    }

    void OnItemCollected(GameObject item, int value, int maxValue)
    {
        playerData.MaxArmor = maxValue;
        OnItemCollected(item, value);
    }
}
