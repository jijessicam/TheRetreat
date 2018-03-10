using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraDrag : MonoBehaviour
{
	public GameObject cam;
	public GameObject head;
	float dragSpeed = .03f;
	private Vector3 dragOrigin;


	void Update ()
	{
		if (Input.GetMouseButtonDown (1)) {
			dragOrigin = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton (1)) {
			return;
		}



		Vector3 rawRot = Input.mousePosition - dragOrigin;
		Vector3 rotAmount = new Vector3 (rawRot.x * dragSpeed, rawRot.y * dragSpeed, 0);


		cam.transform.RotateAround (head.transform.position, Vector3.up, rotAmount.x);

//		Debug.Log ("Cam rotation: " + cam.transform.rotation.eulerAngles);
//		Vector3 camEuler = cam.transform.rotation.eulerAngles;
//		if (camEuler.x >= 0 && camEuler.x < 80)
//			cam.transform.RotateAround (head.transform.position, Vector3.right, rotAmount.y);
//		else if (camEuler.x > 300)
//			cam.transform.SetPositionAndRotation (cam.transform.position, Quaternion.Euler (0, camEuler.y, camEuler.z));
	}


}