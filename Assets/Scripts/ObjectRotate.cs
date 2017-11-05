using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour {

	Vector3 rotationEuler;

	void Update(){
		rotationEuler -= Vector3.forward*360*Time.deltaTime; //increment 360 degrees every second
		transform.rotation = Quaternion.Euler(rotationEuler);
		//To convert Quaternion -> Euler, use eulerAngles
		//print(transform.rotation.eulerAngles);
	}
}
