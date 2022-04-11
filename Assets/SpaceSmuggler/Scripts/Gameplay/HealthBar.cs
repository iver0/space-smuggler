using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    TextMeshProUGUI _healthText;

    void Awake()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        PlayerData.HealthChanged += RenderHealth;
    }

    void OnDisable()
    {
        PlayerData.HealthChanged -= RenderHealth;
    }

    void RenderHealth()
    {
        _healthText.text = $"Health: {_playerData.Health}";
    }
}
