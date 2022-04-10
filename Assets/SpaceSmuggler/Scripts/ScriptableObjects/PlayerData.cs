using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    int _initHealth = 100;
    int _initArmor = 100;
    float _initMoveSpeed = 5f;

    public int MaxHealth;
    [SerializeField] public int Health;
    public int MaxArmor;
    [SerializeField] public int Armor;
    public float MoveSpeed;

    void Awake()
    {
        MaxHealth = _initHealth;
        Health = MaxHealth;
        MaxArmor = _initArmor;
        Armor = 0;
        MoveSpeed = _initMoveSpeed;
    }
}
