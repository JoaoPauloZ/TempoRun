using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame() {
		SceneManager.LoadScene ("Endless");
		//FindObjectOfType<GameManager> ().Reset ();
	}

	public void QuitToMain() {
		SceneManager.LoadScene (mainMenuLevel);
	}
}
