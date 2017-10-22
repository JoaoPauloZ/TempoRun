using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundManager : MonoBehaviour {

	public Transform firstBackground;
	public Transform secondBackground;
	public Transform thirdBackground;
	public Transform thePlayer;

	public float backgraundWidth;

	private Vector3 firstBackgroundStartPosition;
	private Vector3 secondBackgroundStartPosition;
	private Vector3 thirdBackgroundStartPosition;

	private bool switched;

	// Use this for initialization
	void Start () {
		firstBackgroundStartPosition = firstBackground.position;
		secondBackgroundStartPosition = secondBackground.position;
		thirdBackgroundStartPosition = thirdBackground.position;
	}
	
	// Update is called once per frame
	void Update () {

		Transform auxBackground1, auxBackground2;

		if (thePlayer.position.x > secondBackground.position.x && !switched) {
			firstBackground.position = new Vector3 (thirdBackground.position.x + backgraundWidth, 0, 0);

			auxBackground1 = thirdBackground;
			thirdBackground = firstBackground;

			auxBackground2 = secondBackground;
			secondBackground = auxBackground1;

			firstBackground = auxBackground2;

			switched = true;

		} else if (thePlayer.position.x > thirdBackground.position.x - backgraundWidth) {
			switched = false;
		}

	}

	public void RestartBackgroundPosition() {
		firstBackground.position = firstBackgroundStartPosition;
		secondBackground.position = secondBackgroundStartPosition;
		thirdBackground.position = thirdBackgroundStartPosition;
	}
}
