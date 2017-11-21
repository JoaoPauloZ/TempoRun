using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	public DeathMenu theDeathScreen;
	public FinishMenu theFinishScreen;

	public bool increaseScoreByTime;

	public MoveOnEditorPath enemy;
	public EditPathScript path;

	private Vector3 playerStartPoint;

	private ObjectDestroyer[] platformList;

	private ScoreManager theScoreManager;
	private InfinityScrolling[] theInfinityScrollings;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
		theInfinityScrollings = FindObjectsOfType<InfinityScrolling> ();

		theScoreManager.scoreIncreasing = increaseScoreByTime;

		theDeathScreen.gameObject.SetActive (false);
		theFinishScreen.gameObject.SetActive (false);
	}

	public void RestartGame() {
		if (increaseScoreByTime) {
			theScoreManager.scoreIncreasing = false;
		}

		thePlayer.gameObject.SetActive (false);

		theDeathScreen.gameObject.SetActive (true);

		//StartCoroutine ("RestartGameCo");
	}

	public void Reset() {
		theDeathScreen.gameObject.SetActive (false);
		theFinishScreen.gameObject.SetActive (false);
		Time.timeScale = 1;

		platformList = FindObjectsOfType <ObjectDestroyer>();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}

		platformGenerator.position = platformStartPoint;
		thePlayer.transform.position = playerStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.darkMatterCount = 0;

		if (increaseScoreByTime) {
			theScoreManager.scoreIncreasing = true;
		}

		foreach (InfinityScrolling item in theInfinityScrollings) {
			item.RestartBackgroundPosition ();
		}

		enemy.CurrentWayPointID = 0;
		path.path_objs.Clear ();
		enemy.transform.position = playerStartPoint;

	}

	/*
	public IEnumerator RestartGameCo() {

		if (increaseScoreByTime) {
			theScoreManager.scoreIncreasing = false;
		}

		thePlayer.gameObject.SetActive (false);

		yield return new WaitForSeconds (0.5f);

		platformList = FindObjectsOfType <ObjectDestroyer>();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}

		platformGenerator.position = platformStartPoint;
		thePlayer.transform.position = playerStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;

		if (increaseScoreByTime) {
			theScoreManager.scoreIncreasing = true;
		}

		theBackgroundManager.RestartBackgroundPosition ();
	}
	*/

}
