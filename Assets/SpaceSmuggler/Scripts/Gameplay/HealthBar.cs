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
        PlayerHealth.OnHealthChanged += RenderHealth;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= RenderHealth;
    }

    void RenderHealth()
    {
        healthText.text = $"Health: {playerData.Health}";
    }
}
