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

	Transform[] theArray;

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

			if (Random.Range (0f, 100f) < randomCoinTreshold) {
				theCoinGenerator.SpawnCoins (new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z));
			}

			if (theScoreManager.darkMatterCount >= theScoreManager.darkMatterMax && !thePortal.activeInHierarchy) {
				thePortal.transform.position = new Vector3 (newPlatform.transform.position.x, newPlatform.transform.position.y + 2.5f, 0);
				thePortal.SetActive (true);
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);

			Transform cloneTransform;

			cloneTransform = Instantiate (newPlatform.transform);
			PathToFollow.path_objs.Add  (cloneTransform);

			/* Se fizer assim ele cria terian sem estarem associados a uma plataforma. ver uma forma de fazer o caminho mais suave.
			 * theArray = newPlatform.GetComponentsInChildren<Transform> ();
			foreach (Transform path_obj in theArray) {
				if (path_obj != newPlatform.transform) {
					print ("Foreach: " + path_obj);
					cloneTransform = Instantiate (path_obj);

				}
			}*/

		}

	}
}
