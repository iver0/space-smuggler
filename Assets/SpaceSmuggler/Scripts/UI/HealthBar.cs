using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO _playerData;
    TextMeshProUGUI _healthText;

    void Awake()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
        RenderHealth();
    }

    void OnEnable()
    {
        PlayerDataSO.HealthChanged += RenderHealth;
    }

    void OnDisable()
    {
        PlayerDataSO.HealthChanged -= RenderHealth;
    }

    void RenderHealth()
    {
        _healthText.text = $"Health: {_playerData.Health}";
    }
}
