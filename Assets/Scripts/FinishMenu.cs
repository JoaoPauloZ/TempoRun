using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame() {
		FindObjectOfType<GameManager> ().Reset ();
	}

	public void QuitToMain() {
		SceneManager.LoadScene (mainMenuLevel);
	}
}
