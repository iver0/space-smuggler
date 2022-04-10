using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    TextMeshProUGUI healthText;

    void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        PlayerHealth.HealthChanged += RenderHealth;
    }

    void OnDisable()
    {
        PlayerHealth.HealthChanged -= RenderHealth;
    }

    void RenderHealth()
    {
        healthText.text = $"Health: {playerData.Health}";
    }
}
