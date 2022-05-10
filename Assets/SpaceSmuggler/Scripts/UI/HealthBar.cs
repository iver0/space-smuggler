using TMPro;
using UnityEngine;

namespace SpaceSmuggler
{
	public class HealthBar : MonoBehaviour
	{
		[Header("Listening on")]
		[SerializeField] IntEventChannelSO _healthChangedEventChannel = default;
		TextMeshProUGUI _healthText;

		void OnEnable()
		{
			_healthText = GetComponent<TextMeshProUGUI>();
			RenderHealth(100);

			_healthChangedEventChannel.OnEventRaised += RenderHealth;
		}

		void OnDisable()
		{
			_healthChangedEventChannel.OnEventRaised -= RenderHealth;
		}

		void RenderHealth(int health)
		{
			_healthText.text = $"Health: {health}";
		}
	}
}
