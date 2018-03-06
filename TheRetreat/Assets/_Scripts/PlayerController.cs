using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float walkSpeed = 4.0f;
	public Rigidbody rigidBody;


	void Update ()
	{

		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * walkSpeed;

		transform.Rotate (0, x, 0);
		transform.Translate(0, 0, z);

//		rigidBody.AddForce (Vector3.forward * walkSpeed);


	}
}
