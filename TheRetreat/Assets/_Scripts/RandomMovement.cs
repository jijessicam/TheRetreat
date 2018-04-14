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

	void Start() {
		getNextPos ();
	}

	void Update ()
	{



		// if rotation not at waypoint, lerp rotation to the waypoint



		float step = rotateSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, new Vector3(waypoint.x, 0f, waypoint.z), step, 0.0f);

		// Move our position a step closer to the target.
		transform.rotation = Quaternion.LookRotation(newDir);

		Debug.Log ("current rot: " + transform.rotation.eulerAngles);
		Debug.Log ("waypoint: " + waypoint);
		Debug.Log ("new dir: " + newDir);



		// if position not at waypoint, lerp movement to the waypoint
		if (transform.position.x != waypoint.x && transform.position.z != waypoint.z) {
			step = walkSpeed * Time.deltaTime;
			Vector3 nextPos = Vector3.MoveTowards (transform.position, waypoint, step);

//			transform.position = nextPos

			RaycastHit hit;
			if (Physics.Raycast (bottom.transform.position, -Vector3.up, out hit)) {
	
				if (hit.collider.gameObject.name == ("Terrain")) {
	
					transform.position = (new Vector3 (nextPos.x, hit.point.y + bottom.transform.position.y, nextPos.z));
					return;
				}
			} else if (Physics.Raycast (bottom.transform.position, Vector3.up, out hit)) {
	
				if (hit.collider.gameObject.name == ("Terrain")) {
					float distanceToGround = hit.distance;
					transform.position = (new Vector3 (nextPos.x, hit.point.y - bottom.transform.position.y, nextPos.z));
					return;
				}
			}

		} else {
			getNextPos ();
		}




		









//
//
//
//
//
//
//
//
//
//
//		nextStep = getNextPos ();
//
//
//		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
//		var z = Input.GetAxis ("Vertical") * Time.deltaTime * walkSpeed;
//
//		// get distance to ground
//
//		transform.Rotate (0, x, 0);
//
//

	}

	void getNextPos() {

		nextRandomPoint = Random.insideUnitCircle * randomWalkArea;
		waypoint = new Vector3 (nextRandomPoint.x, 0f, nextRandomPoint.y) + transform.position;
	}

}
