using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePortal;
	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	//public GameObject[] thePlatforms;

	private float distanceBetween;
	private float platformWidth;
	private int platformSelector;
	private float[] platformWidths;

	public ObjectPooler[] theObjectPools;

	public Transform maxHeightPoint;
	public float maxHeightChange;
	private float heightChange;
	private float minHeight;
	private float maxHeight;

	private CoinGenerator theCoinGenerator;
	public float randomCoinTreshold;

	//private GameObject theRealPortal;
	private ScoreManager theScoreManager;

	public EditPathScript PathToFollow;

	public GameObject FirstPlatform;

	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		// altura minima será o centro da primeira plataforma
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerator = FindObjectOfType<CoinGenerator> ();

		theScoreManager = FindObjectOfType<ScoreManager> ();

		float x = FirstPlatform.transform.position.x;
		float y = FirstPlatform.transform.position.y;
		float z = FirstPlatform.transform.position.z;

		PathToFollow.path_objs.Add  (new Vector3(x-7f, y + 1.5f, z));

		PathToFollow.path_objs.Add  (new Vector3(x, y + 1.5f, z));

		PathToFollow.path_objs.Add  (new Vector3(x+7.4f, y + 1.75f, z));

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range (0, theObjectPools.Length);

			heightChange = Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

			//Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);

			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject ();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			float x = transform.position.x;
			float y = transform.position.y;
			float z = transform.position.z;

			if (Random.Range (0f, 100f) < randomCoinTreshold) {
				theCoinGenerator.SpawnCoins (new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z));
			}

			if (theScoreManager.darkMatterCount >= theScoreManager.darkMatterMax && !thePortal.activeInHierarchy) {
				thePortal.transform.position = new Vector3 (newPlatform.transform.position.x, newPlatform.transform.position.y + 2.5f, 0);
				thePortal.SetActive (true);
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);

			if (platformSelector == 0) {
				PathToFollow.path_objs.Add (new Vector3 (x - 1.3f, y + 1.75f, z));
				PathToFollow.path_objs.Add (new Vector3 (x, y + 1.5f, z));
				PathToFollow.path_objs.Add (new Vector3 (x + 1.4f, y + 1.75f, z));
			} else if (platformSelector == 1) {
				PathToFollow.path_objs.Add (new Vector3 (x - 2.5f, y + 1.75f, z));
				PathToFollow.path_objs.Add (new Vector3 (x, y + 1.5f, z));
				PathToFollow.path_objs.Add (new Vector3 (x + 2.5f, y + 1.75f, z));
			} else if (platformSelector ==	2) {
				PathToFollow.path_objs.Add (new Vector3 (x - 6.1f, y + 1.75f, z));
				PathToFollow.path_objs.Add (new Vector3 (x, y + 1.5f, z));
				PathToFollow.path_objs.Add (new Vector3 (x + 6.4f, y + 1.75f, z));
			} else if (platformSelector ==	3) {
				PathToFollow.path_objs.Add (new Vector3 (x - 7f, y + 1.75f, z));
				PathToFollow.path_objs.Add (new Vector3 (x, y + 1.5f, z));
				PathToFollow.path_objs.Add (new Vector3 (x + 7.4f, y + 1.75f, z));
			}

		}

	}
}
