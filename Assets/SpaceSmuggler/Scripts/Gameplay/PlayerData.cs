using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
{
    int initHealth = 100;
    int initArmor = 100;
    float initMoveSpeed = 5f;

    [NonSerialized]
    public int MaxHealth;
    public int Health;
    public int MaxArmor;
    public int Armor;
    public float MoveSpeed;

    public void OnAfterDeserialize()
    {
        MaxHealth = initHealth;
        Health = MaxHealth;
        MaxArmor = initArmor;
        Armor = 0;
        MoveSpeed = initMoveSpeed;
    }

    public void OnBeforeSerialize() { }
}
