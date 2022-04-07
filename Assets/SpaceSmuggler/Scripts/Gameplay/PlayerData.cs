using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
{
    int initHealth;
    int initArmor;

    [NonSerialized]
    public int MaxHealth;
    public int Health;
    public int MaxArmor;
    public int Armor;

    public void OnAfterDeserialize()
    {
        MaxHealth = initHealth;
        Health = MaxHealth;
        MaxArmor = initArmor;
        Armor = MaxArmor;
    }

    public void OnBeforeSerialize() { }
}
