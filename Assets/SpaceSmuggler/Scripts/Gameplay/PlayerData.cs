using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
{
    int _initHealth = 100;
    int _initArmor = 100;
    float _initMoveSpeed = 5f;

    public int MaxHealth;
    public int Health;
    public int MaxArmor;
    public int Armor;
    public float MoveSpeed;

    public void OnAfterDeserialize()
    {
        MaxHealth = _initHealth;
        Health = MaxHealth;
        MaxArmor = _initArmor;
        Armor = 0;
        MoveSpeed = _initMoveSpeed;
    }

    public void OnBeforeSerialize() { }
}
