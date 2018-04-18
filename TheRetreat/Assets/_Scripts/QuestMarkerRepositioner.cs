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
		player = GameObject.Find ("player");

		// get the name of the thing to point to from the name of the marker (this is the convention we are using rn)
		string colliderString = this.transform.name;
		colliderString = colliderString.Substring (3, colliderString.Length - 3);

		questTarget = GameObject.Find (colliderString);

		imageRect = this.gameObject.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {

		// cast a ray from player to target
		Vector3 playerPosXZ = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
		Vector3 questPosXZ = new Vector3(questTarget.transform.position.x, 0f, questTarget.transform.position.z);
		Vector3 vectorFromTargetToPlayer = questPosXZ - playerPosXZ;
		vectorFromTargetToPlayer.Normalize ();

		Vector3 centerOfCompass = new Vector3(player.transform.forward.x, 0f, player.transform.forward.z);

		float angleToQuestTarget = Vector3.SignedAngle (centerOfCompass, vectorFromTargetToPlayer, player.transform.position);

		float normalizedAngle = angleToQuestTarget / angleOfRightmostness;
		if (normalizedAngle > 1.0f)
			normalizedAngle = 1.0f;
		if (normalizedAngle < -1.0f)
			normalizedAngle = -1.0f;
		
		imageRect.localPosition = new Vector3(normalizedAngle * endOfRightCompassXBound, imageRect.localPosition.y, imageRect.localPosition.z);
	}
}
