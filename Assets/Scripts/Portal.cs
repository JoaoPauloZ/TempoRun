using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	
	public GameObject theFinishScreen;

	void Start() {
		this.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Player") {
			other.gameObject.SetActive (false);
			theFinishScreen.SetActive (true);
			Time.timeScale = 0;
		}
	}

}
