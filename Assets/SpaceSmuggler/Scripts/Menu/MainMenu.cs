using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceSmuggler
{
	public class MainMenu : MonoBehaviour
	{
		public void PlayGame()
		{
			SceneManager.LoadScene("Level_0");
		}

		public void QuitGame()
		{
			Application.Quit();
		}
	}
}
