using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager theScoreManager;
	private AudioSource darkMatterSound;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		darkMatterSound = GameObject.Find ("DarkMatterSound").GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Player") {
			theScoreManager.AddScore(scoreToGive);
			gameObject.SetActive (false);
			if (darkMatterSound.isPlaying) {
				darkMatterSound.Stop ();
			}
			darkMatterSound.Play ();
		}
	}
}
