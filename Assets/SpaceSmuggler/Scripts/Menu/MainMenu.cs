using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceSmuggler
{
	/// <summary>
	/// Class for main menu logic.
	/// </summary>
	public class MainMenu : MonoBehaviour
	{
		/// <summary
		/// Loads the level.
		/// </summary>
		public void PlayGame()
		{
			SceneManager.LoadScene("Level_0");
		}

		/// <summary>
		/// Exits the game.
		/// </summary>
		public void QuitGame()
		{
			Application.Quit();
		}
	}
}
