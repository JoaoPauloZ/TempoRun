using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnEditorPath : MonoBehaviour {

	public EditPathScript PathToFollow;

	public int CurrentWayPointID = 0;
	public float speed;
	private float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;
	public string PathName;

	Vector3 last_position;
	Vector3 current_position;

	// Use this for initialization
	void Start () {
		//PathToFollow = GameObject.Find (PathName).GetComponent<EditPathScript>();
		last_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (PathToFollow.path_objs.Count > 0) {
			float distance = Vector3.Distance (PathToFollow.path_objs [CurrentWayPointID], transform.position);
			transform.position = Vector3.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID], Time.fixedDeltaTime * speed);

			//var rotation = Quaternion.LookRotation (PathToFollow.path_objs [CurrentWayPointID] - transform.position);
			//transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);

			if (distance <= reachDistance && CurrentWayPointID < PathToFollow.path_objs.Count - 1) {
				CurrentWayPointID++;		
			}
		}
	}
}
