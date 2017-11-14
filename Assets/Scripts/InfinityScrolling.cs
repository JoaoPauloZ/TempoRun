using UnityEngine;

public class InfinityScrolling : MonoBehaviour {

	public Transform firstBackground;
	public Transform secondBackground;
	public Transform thePlayer;

	public float backgraundWidth;

	private Vector3 firstBackgroundStartPosition;
	private Vector3 secondBackgroundStartPosition;

	private bool switched;

	// Use this for initialization
	void Start () {
		firstBackgroundStartPosition = firstBackground.position;
		secondBackgroundStartPosition = secondBackground.position;
	}
	
	// Update is called once per frame
	void Update () {
		Transform auxBackground1, auxBackground2;

		if (thePlayer.position.x > secondBackground.position.x - 4 && !switched) {
			firstBackground.position = new Vector3 (secondBackground.position.x + backgraundWidth, secondBackground.position.y, 0);

			auxBackground1 = secondBackground;
			auxBackground2 = firstBackground;

			firstBackground = auxBackground1;
			secondBackground = auxBackground2;

			switched = true;

		} else if (thePlayer.position.x > secondBackground.position.x - 4) {
			switched = false;
		}

	}

	public void RestartBackgroundPosition() {
		firstBackground.position = firstBackgroundStartPosition;
		secondBackground.position = secondBackgroundStartPosition;
	}
}
