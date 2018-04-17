using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class CompassQuestMarkerHandler : MonoBehaviour {

	public GameObject questMarkerPrefab;

	// Use this for initialization
	void Start () {
		QuestLog.AddQuestStateObserver("Find Your Tent", LuaWatchFrequency.EveryDialogueEntry, OnQuestStateChanged);
	}
	
	void OnQuestStateChanged(string title, QuestState newState) {

		// make a quest marker on the tent
		if (newState == QuestState.Active) {

			GameObject collider = GameObject.Find ("FindYourTentQuestCollider");


			GameObject questMarker = Instantiate (questMarkerPrefab, this.transform);
			questMarker.name = "QM_FindYourTentQuestCollider";
		}
	}
}
