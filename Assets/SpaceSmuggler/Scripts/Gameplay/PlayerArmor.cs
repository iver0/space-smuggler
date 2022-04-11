using System;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    public static event Action<GameObject> ItemCollected;
    [SerializeField] PlayerData _playerData;

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
        if (_playerData.Armor != _playerData.MaxArmor)
        {
            if (_playerData.Armor + value < _playerData.MaxArmor)
            {
                _playerData.Armor += value;
            }
            else
            {
                _playerData.Armor = _playerData.MaxArmor;
            }
            ItemCollected?.Invoke(item);
        }
    }

    void OnItemCollected(GameObject item, int value, int maxValue)
    {
        _playerData.MaxArmor = maxValue;
        OnItemCollected(item, value);
    }
}
