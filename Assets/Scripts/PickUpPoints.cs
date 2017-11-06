using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Player") {
			theScoreManager.AddScore(scoreToGive);
			gameObject.SetActive (false);
		}
	}
}
