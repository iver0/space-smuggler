using System;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    public static event Action OnArmorChanged;
    [SerializeField] PlayerData playerData;

    void OnEnable()
    {
        Armor.OnArmorCollected += ChangeArmor;
        LightArmor.OnLightArmorCollected += ChangeArmor;
        HeavyArmor.OnHeavyArmorCollected += ChangeArmor;
    }

    void OnDisable()
    {
        Armor.OnArmorCollected -= ChangeArmor;
        LightArmor.OnLightArmorCollected -= ChangeArmor;
        HeavyArmor.OnHeavyArmorCollected -= ChangeArmor;
    }

    void ChangeArmor(int value)
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
            OnArmorChanged?.Invoke();
        }
    }

    void ChangeArmor(int value, int maxValue)
    {
        playerData.MaxArmor = maxValue;
        ChangeArmor(value);
    }
}
