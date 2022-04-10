using System;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    public static event Action OnArmorChanged;
    public static event Action<GameObject> OnCollectibleCollected;
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

    void ChangeArmor(GameObject collectible, int value)
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
            OnCollectibleCollected?.Invoke(collectible);
            OnArmorChanged?.Invoke();
        }
    }

    void ChangeArmor(GameObject collectible, int value, int maxValue)
    {
        playerData.MaxArmor = maxValue;
        ChangeArmor(collectible, value);
    }
}
