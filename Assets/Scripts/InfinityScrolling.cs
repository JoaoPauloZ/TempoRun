using UnityEngine;

public class InfinityScrolling : MonoBehaviour {

	public Transform firstBackground;
	public Transform secondBackground;

	public float backgraundWidth;
	public float parallaxSpeed;

	private Transform cameraTransform;
	private float firstCameraX;
	private float lastCameraX;

	private Vector3 firstBackgroundStartPosition;
	private Vector3 secondBackgroundStartPosition;

	private bool switched;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		firstCameraX = cameraTransform.position.x;
		firstBackgroundStartPosition = firstBackground.position;
		secondBackgroundStartPosition = secondBackground.position;
	}
	
	// Update is called once per frame
	void Update () {
		Transform auxBackground1, auxBackground2;

		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * parallaxSpeed);
		lastCameraX = cameraTransform.position.x;

		if (cameraTransform.position.x > secondBackground.position.x && !switched) {
			firstBackground.position = new Vector3 (secondBackground.position.x + backgraundWidth, secondBackground.position.y, 0);

			auxBackground1 = secondBackground;
			auxBackground2 = firstBackground;

			firstBackground = auxBackground1;
			secondBackground = auxBackground2;

			switched = true;

		} else if (cameraTransform.position.x > secondBackground.position.x) {
			switched = false;
		}

	}

	public void RestartBackgroundPosition() {
		firstBackground.position = firstBackgroundStartPosition;
		secondBackground.position = secondBackgroundStartPosition;
		lastCameraX = firstCameraX;
	}
}
