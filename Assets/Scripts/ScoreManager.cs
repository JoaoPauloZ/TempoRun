﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	//public Text highScoreText;

	public float darkMatterCount;
	public float darkMatterMax;

	public float distanceCount;
	public float highDistanceCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		//if (PlayerPrefs.HasKey("HighScore")) {
		//	highDistanceCount = PlayerPrefs.GetFloat ("HighScore");
		//}
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) {
			darkMatterCount += pointsPerSecond * Time.deltaTime;
		}

		//if (darkMatterCount > highDistanceCount) {
		//	highDistanceCount = darkMatterCount;
		//	PlayerPrefs.SetFloat ("HighScore", highDistanceCount);
		//}

		float count = Mathf.Round (darkMatterCount);

		if (count < 10) {
			scoreText.text = "0" + count + "/" + darkMatterMax;
		} else {
			scoreText.text = count + "/" + darkMatterMax;
		}

		//highScoreText.text = "High Score: " + Mathf.Round(highDistanceCount);

	}

	public void AddScore (int pointsToAdd) {
		darkMatterCount += pointsToAdd;
	}

}
