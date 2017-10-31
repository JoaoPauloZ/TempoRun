using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	public bool increaseScoreByTime;

	private Vector3 playerStartPoint;

	private ObjectDestroyer[] platformList;

	private ScoreManager theScoreManager;
	private BackgroundManager theBackgroundManager;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
		theBackgroundManager = FindObjectOfType<BackgroundManager> ();

		theScoreManager.scoreIncreasing = increaseScoreByTime;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame() {

		StartCoroutine ("RestartGameCo");

	}

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

}
