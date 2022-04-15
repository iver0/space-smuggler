using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Gameplay/Player Data")]
public class PlayerDataSO : ScriptableObject, ISerializationCallbackReceiver
{
	public static UnityAction HealthChanged;
	public static UnityAction ArmorChanged;
	[SerializeField] int m_MaxHealth;
	[SerializeField] int m_MaxArmor;
	[SerializeField] int m_Health;
	[SerializeField] int m_Armor;
	[SerializeField] float m_MoveSpeed;
	[NonSerialized] public int MaxHealth;
	[NonSerialized] public int MaxArmor;
	[NonSerialized] public float MoveSpeed;
	int _health;
	public int Health
	{
		get { return _health; }
		set
		{
			HealthChanged?.Invoke();
			_health = value;
		}
	}
	int _armor;
	public int Armor
	{
		get { return _armor; }
		set
		{
			ArmorChanged?.Invoke();
			_armor = value;
		}
	}

	public void OnAfterDeserialize()
	{
		MaxHealth = m_MaxHealth;
		MaxArmor = m_MaxArmor;
		Health = m_Health;
		Armor = m_Armor;
		MoveSpeed = m_MoveSpeed;
	}

	public void OnBeforeSerialize() { }
}
