using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceSmuggler
{
	public class PauseMenu : MonoBehaviour
	{
		public static event Action<GameState> ChangeGameStateEvent;
		[SerializeField] InputReaderSO _inputReader = default;
		[SerializeField] GameObject _pauseMenu;

		void Awake()
		{
			_pauseMenu.SetActive(false);
		}

		void OnEnable()
		{
			_inputReader.PauseEvent += OnPause;
			_inputReader.ResumeEvent += OnResume;
		}

		void OnDisable()
		{
			_inputReader.PauseEvent -= OnPause;
			_inputReader.ResumeEvent -= OnResume;
		}

		public void QuitGame()
		{
			OnResume();
			SceneManager.LoadScene("MainMenu");
		}

		#region EventListeners
		void OnPause()
		{
			ChangeGameStateEvent?.Invoke(GameState.Pause);
			_pauseMenu.SetActive(true);
		}

		void OnResume()
		{
			ChangeGameStateEvent?.Invoke(GameState.Play);
			_pauseMenu.SetActive(false);
		}
		#endregion
	}
}
