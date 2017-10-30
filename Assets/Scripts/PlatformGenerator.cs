﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

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

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);

		}

	}
}
