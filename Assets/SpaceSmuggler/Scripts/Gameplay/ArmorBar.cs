using UnityEngine;
using TMPro;

public class ArmorBar : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    TextMeshProUGUI armorText;

    void Awake()
    {
        armorText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        PlayerArmor.ArmorChanged += RenderArmor;
    }

    void OnDisable()
    {
        PlayerArmor.ArmorChanged -= RenderArmor;
    }

    void RenderArmor()
    {
        armorText.text = $"Armor: {playerData.Armor}";
    }
}
