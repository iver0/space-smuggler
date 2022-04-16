using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Gameplay/Player Data")]
public class PlayerDataSO : ScriptableObject, ISerializationCallbackReceiver
{
	public static event Action ArmorChanged;
	[SerializeField] int m_maxHealth;
	[SerializeField] int m_maxArmor;
	[SerializeField] int m_health;
	[SerializeField] int m_armor;
	[SerializeField] float m_moveSpeed;
	[Header("Broadcasting on")]
	[SerializeField] IntEventChannelSO _healthChangedEventChannel = default;
	[SerializeField] VoidEventChannelSO _playerDeathEventChannel = default;
	[NonSerialized] public int MaxHealth;
	[NonSerialized] public int MaxArmor;
	[NonSerialized] public float MoveSpeed;
	int _health;
	public int Health
	{
		get { return _health; }
		set
		{
			if (value <= 0)
				_playerDeathEventChannel.RaiseEvent();
			_health = value;
			_healthChangedEventChannel.RaiseEvent(value);
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
		MaxHealth = m_maxHealth;
		MaxArmor = m_maxArmor;
		Health = m_health;
		Armor = m_armor;
		MoveSpeed = m_moveSpeed;
	}

	public void OnBeforeSerialize() { }
}
