using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
{
    public static event Action HealthChanged;
    public static event Action ArmorChanged;

    [SerializeField] int m_MaxHealth;
    [SerializeField] int m_Health;
    [SerializeField] int m_MaxArmor;
    [SerializeField] int m_Armor;
    [SerializeField] float m_MoveSpeed;

    [NonSerialized] public int MaxHealth;
    [NonSerialized] int _health;
    public int Health { get { return _health; } set { HealthChanged?.Invoke(); _health = value; } }
    [NonSerialized] public int MaxArmor;
    [NonSerialized] int _armor;
    public int Armor { get { return _armor; } set { ArmorChanged?.Invoke(); _armor = value; } }
    [NonSerialized] public float MoveSpeed;

    public void OnAfterDeserialize()
    {
        MaxHealth = m_MaxHealth;
        Health = m_Health;
        MaxArmor = m_MaxArmor;
        Armor = m_Armor;
        MoveSpeed = m_MoveSpeed;
    }

    public void OnBeforeSerialize() { }
}
