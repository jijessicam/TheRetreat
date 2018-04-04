using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject bottom;
	public float walkSpeed = 4.0f;
	public Rigidbody rigidBody;

	void Update ()
	{
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * walkSpeed;

		// get distance to ground

		transform.Rotate (0, x, 0);


		RaycastHit hit;
		if (Physics.Raycast (bottom.transform.position, -Vector3.up, out hit)) {

			if (hit.collider.gameObject.name == ("Terrain")) {

				float distanceToGround = hit.distance;
				transform.Translate (new Vector3 (0, -distanceToGround * .5f, z));
				return;
			}
		} else if (Physics.Raycast (bottom.transform.position, Vector3.up, out hit)) {

			if (hit.collider.gameObject.name == ("Terrain")) {
				float distanceToGround = hit.distance;
				transform.Translate (new Vector3 (0, distanceToGround * .5f, z));
				return;
			}
		}

		transform.Translate (0, 0, z);

//
//		transform.Translate(new Vector3(transform.position.x, transform.position.y + distanceToGround, transform.position.z));

//		rigidBody.AddForce (Vector3.forward * walkSpeed);


	}
}
