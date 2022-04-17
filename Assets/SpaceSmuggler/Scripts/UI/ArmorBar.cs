using TMPro;
using UnityEngine;

namespace SpaceSmuggler
{
	public class ArmorBar : MonoBehaviour
	{
		[SerializeField] PlayerDataSO _playerData;
		TextMeshProUGUI _armorText;

		void Awake()
		{
			_armorText = GetComponent<TextMeshProUGUI>();
			RenderArmor();
		}

		void OnEnable()
		{
			PlayerDataSO.ArmorChanged += RenderArmor;
		}

		void OnDisable()
		{
			PlayerDataSO.ArmorChanged -= RenderArmor;
		}

		void RenderArmor()
		{
			_armorText.text = $"Armor: {_playerData.Armor}";
		}
	}
}
