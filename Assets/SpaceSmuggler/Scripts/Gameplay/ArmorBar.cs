using UnityEngine;
using TMPro;

public class ArmorBar : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    TextMeshProUGUI _armorText;

    void Awake()
    {
        _armorText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        PlayerData.ArmorChanged += RenderArmor;
    }

    void OnDisable()
    {
        PlayerData.ArmorChanged -= RenderArmor;
    }

    void RenderArmor()
    {
        _armorText.text = $"Armor: {_playerData.Armor}";
    }
}
