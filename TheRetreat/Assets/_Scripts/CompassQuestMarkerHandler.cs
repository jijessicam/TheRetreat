using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class CompassQuestMarkerHandler : MonoBehaviour {

	public GameObject questMarkerPrefab;

	private Hashtable activeMarkers;

	// Use this for initialization
	void Start () {
		QuestLog.AddQuestStateObserver ("Find Your Tent", LuaWatchFrequency.EveryUpdate, OnQuestStateChanged);
		activeMarkers = new Hashtable();
	}

	void OnQuestStateChanged (string title, QuestState newState) {

		// make a quest marker on the tent
		if (newState == QuestState.Active) {

			GameObject collider = GameObject.Find ("FindYourTentQuestCollider");

			GameObject questMarker = Instantiate (questMarkerPrefab, this.transform) as GameObject;

			questMarker.name = "QM_FindYourTentQuestCollider";

			activeMarkers.Add (title, questMarker);
		} else {
			// inactive quests don't get marker
			GameObject marker = activeMarkers[title] as GameObject;
			if (marker != null) {
				activeMarkers.Remove(title);
				Destroy(marker);
			}
		}
	}
}