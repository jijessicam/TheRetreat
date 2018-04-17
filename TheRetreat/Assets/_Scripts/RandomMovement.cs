using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

	public GameObject bottom;
	float walkSpeed = 2f;
	// Angular speed in radians per sec.
	float rotateSpeed = 0.5f;
	float randomWalkArea = 10f;


	private Vector2 nextRandomPoint;
	private Vector3 waypoint;
	private Vector3 lastPos;

	void Start() {
		getNextPos ();
	}

	void Update ()
	{



		// if rotation not at waypoint, lerp rotation to the waypoint



		float step = rotateSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, new Vector3(waypoint.x, 0f, waypoint.z), step, 1f);

		// Move our position a step closer to the target.
		transform.rotation = Quaternion.LookRotation(newDir);

//		Debug.Log ("current rot: " + transform.rotation.eulerAngles);
//		Debug.Log ("new dir: " + newDir);

//		Debug.Log ("current position: " + transform.position);
//		Debug.Log ("waypoint: " + waypoint);




		// if position not at waypoint, lerp movement to the waypoint
		if (transform.position.x != waypoint.x || transform.position.z != waypoint.z) {
			step = walkSpeed * Time.deltaTime;
			Vector3 nextPos = Vector3.MoveTowards (transform.position, waypoint, step);

//			transform.position = nextPos

			RaycastHit hit;
			if (Physics.Raycast (bottom.transform.position, -Vector3.up, out hit)) {
	
				if (hit.collider.gameObject.name == ("Terrain")) {

					float distanceToGround = hit.distance;
	
					transform.position = (new Vector3 (nextPos.x, -distanceToGround * .5f + transform.position.y, nextPos.z));
					return;
				}
			} else if (Physics.Raycast (bottom.transform.position, Vector3.up, out hit)) {
	
				if (hit.collider.gameObject.name == ("Terrain")) {
					float distanceToGround = hit.distance;
					transform.position = (new Vector3 (nextPos.x, distanceToGround * .5f + transform.position.y, nextPos.z));
					return;
				}
			}
			lastPos = transform.position;
			transform.position = (new Vector3 (nextPos.x, transform.position.y, nextPos.z));
			if (transform.position == lastPos) {
				getNextPos ();
			}
		} else {
			getNextPos ();
			Debug.Log ("GETTING NEXT POSITION");
		}
	}

	void getNextPos() {

		nextRandomPoint = Random.insideUnitCircle * randomWalkArea;
		waypoint = new Vector3 (nextRandomPoint.x, 0f, nextRandomPoint.y) + transform.position;
	}

}
