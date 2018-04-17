using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarkerRepositioner : MonoBehaviour {

	private GameObject player;
	private GameObject questTarget;
	private RectTransform imageRect;

	private float endOfRightCompassXBound = 195f;
	private float angleOfRightmostness = 60f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");

		// get the name of the thing to point to from the name of the marker (this is the convention we are using rn)
		string colliderString = this.transform.name;
		colliderString = colliderString.Substring (3, colliderString.Length - 3);

		Debug.Log (colliderString);

		questTarget = GameObject.Find (colliderString);

		imageRect = this.gameObject.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {

		// cast a ray from player to tent
		Vector3 vectorToTentFromPlayer = questTarget.transform.position - player.transform.position;
		Vector3 centerOfCompass = player.transform.forward;

		float angleToQuestTarget = Vector3.SignedAngle (centerOfCompass, vectorToTentFromPlayer, player.transform.position);

//		Debug.Log ("Angle from thang: " + angleToQuestTarget);

		float normalizedAngle = angleToQuestTarget / angleOfRightmostness;
		if (normalizedAngle > 1.0f)
			normalizedAngle = 1.0f;
		if (normalizedAngle < -1.0f)
			normalizedAngle = -1.0f;

		Debug.Log ("NOMRALIZED ANGLE: " + normalizedAngle);
		Debug.Log ("NEW X POS: " + normalizedAngle * endOfRightCompassXBound);
		
		imageRect.localPosition = new Vector3(normalizedAngle * endOfRightCompassXBound, imageRect.position.y, imageRect.position.z);
	}
}
